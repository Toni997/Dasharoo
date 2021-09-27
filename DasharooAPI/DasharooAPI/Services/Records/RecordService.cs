using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DasharooAPI.Controllers;
using DasharooAPI.Data;
using DasharooAPI.IRepository;
using DasharooAPI.Models;
using DasharooAPI.Services.Records;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Razor.Language.CodeGeneration;
using Microsoft.EntityFrameworkCore.Query;
using Org.BouncyCastle.Asn1.X509.Qualified;

namespace DasharooAPI.Services
{
    public class RecordService : IRecordService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IFileService _fileService;

        public RecordService(IUnitOfWork unitOfWork, IMapper mapper, IFileService fileService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _fileService = fileService;
        }

        public async Task<IList<RecordDto>> GetAllWithAuthorsGenresSupporters()
        {
            var records = await _unitOfWork.Records.GetAllWithAuthorsGenresSupporters();
            var recordsDto = _mapper.Map<IList<RecordDto>>(records);
            return recordsDto;
        }
        public async Task<IList<RecordForSearchDto>> GetByKeywordWithAuthorsGenresSupporters(string keyword)
        {
            var records = await _unitOfWork.Records.GetByKeywordWithAuthorsGenresSupporters(keyword);
            var recordsDto = _mapper.Map<IList<RecordForSearchDto>>(records);
            return recordsDto;
        }

        public async Task<RecordDto> GetByIdWithAuthorsGenresSupporters(int id)
        {
            var record = await _unitOfWork.Records.GetByIdWithAuthorsGenresSupporters(id);
            if (record == null) return null;

            var recordDto = _mapper.Map<RecordDto>(record);
            return recordDto;
        }

        public async Task<bool> TryDeleteAndReturnBool(int id)
        {
            var record = await _unitOfWork.Records.GetById(id);

            if (record == null) return false;

            await _unitOfWork.Records.Delete(id);
            await _unitOfWork.Save();

            return true;
        }

        public async Task<ResponseDetails> TryCreateAndReturnResponseDetails(CreateRecordDto recordDto)
        {
            var record = _mapper.Map<Record>(recordDto);
            record.CreatedById = "f2fc5610-1830-451a-ad1b-3732c32b2970";

            // uploading audio file
            var resultAudio = await _fileService.UploadFile(
                recordDto.Source, _fileService.RecordSourcesDir, FileTypes.Audio);
            if (!resultAudio.Succeeded) return (Error)resultAudio;
            record.SourcePath = (string)resultAudio.Value;

            // uploading image file
            if (recordDto.Image != null)
            {
                var resultImage = await _fileService.UploadFile(
                    recordDto.Image, _fileService.RecordImagesDir, FileTypes.Image);
                if (!resultImage.Succeeded) return (Error)resultImage;
                record.ImagePath = (string)resultImage.Value;
            }

            await _unitOfWork.Records.Insert(record);
            await _unitOfWork.Save();

            await CreateRelatedData(record, recordDto);

            await _unitOfWork.Save();

            return new Success(StatusCodes.Status201Created, record);
        }

        private async Task CreateRelatedData(Record record, CreateRecordDto recordDto)
        {
            foreach (var genreId in recordDto.GenresIds)
            {
                await _unitOfWork.RecordGenres.Insert(new RecordGenre
                {
                    RecordId = record.Id,
                    GenreId = genreId,
                });
            }
            foreach (var authorId in recordDto.AuthorsIds)
            {
                await _unitOfWork.RecordAuthors.Insert(new RecordAuthor
                {
                    RecordId = record.Id,
                    AuthorId = authorId,
                });
            }
        }

        public async Task<ResponseDetails> TryUpdateAndReturnResponseDetails(int id, UpdateRecordDto recordDto)
        {
            var record = await _unitOfWork.Records.Get(x => x.Id == id);
            if (record == null) return new Error(
                StatusCodes.Status404NotFound, "Record with that id doesn't exist.");

            _mapper.Map(recordDto, record);

            // uploading audio file
            if (recordDto.Source != null)
            {
                var resultAudio = await _fileService.UploadFile(
                    recordDto.Source, _fileService.RecordSourcesDir, FileTypes.Audio, record.SourcePath);
                if (!resultAudio.Succeeded) return (Error)resultAudio;
                record.SourcePath = (string)resultAudio.Value;
            }

            // uploading image file
            if (recordDto.Image != null)
            {
                var resultImage = await _fileService.UploadFile(
                    recordDto.Image, _fileService.RecordImagesDir, FileTypes.Image, record.ImagePath);
                if (!resultImage.Succeeded) return (Error)resultImage;
                record.ImagePath = (string)resultImage.Value;
            }

            _unitOfWork.Records.Update(record);

            await UpdateRelatedData(record, recordDto);

            await _unitOfWork.Save();

            return new Success(StatusCodes.Status204NoContent, null);
        }

        private async Task UpdateRelatedData(Record record, UpdateRecordDto recordDto)
        {
            var genresToDelete = await _unitOfWork.RecordGenres.GetAll(
                x => x.RecordId == record.Id
                     && !recordDto.GenresIds.Contains(x.GenreId));
            _unitOfWork.RecordGenres.DeleteRange(genresToDelete);

            var authorsToDelete = await _unitOfWork.RecordAuthors.GetAll(
                x => x.RecordId == record.Id
                     && !recordDto.AuthorsIds.Contains(x.AuthorId));
            _unitOfWork.RecordAuthors.DeleteRange(authorsToDelete);

            foreach (var genreId in recordDto.GenresIds)
            {
                var recordGenre = await _unitOfWork.RecordGenres.Get(
                    x => x.RecordId == record.Id
                         && x.GenreId == genreId);
                if (recordGenre == null)
                {
                    await _unitOfWork.RecordGenres.Insert(new RecordGenre
                    {
                        RecordId = record.Id,
                        GenreId = genreId,
                    });
                }
            }

            foreach (var authorId in recordDto.AuthorsIds)
            {
                var recordAuthor = await _unitOfWork.RecordAuthors.Get(
                    x => x.RecordId == record.Id
                         && x.AuthorId == authorId);
                if (recordAuthor == null)
                {
                    await _unitOfWork.RecordAuthors.Insert(new RecordAuthor
                    {
                        RecordId = record.Id,
                        AuthorId = authorId,
                    });
                }
            }
        }
    }
}
