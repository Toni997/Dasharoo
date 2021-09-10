using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DasharooAPI.Data;
using DasharooAPI.Models;

namespace DasharooAPI.Services.Records
{
    public interface IRecordService
    {
        Task<bool> TryDeleteAndReturnBool(int id);
        Task<ResponseDetails> TryCreateAndReturnResponseDetails(CreateRecordDto recordDto);
        Task<ResponseDetails> TryUpdateAndReturnResponseDetails(int id, UpdateRecordDto recordDto);
        Task<IList<RecordDto>> GetAllWithAuthorsGenresSupporters();
        Task<RecordDto> GetByIdWithAuthorsGenresSupporters(int id);
    }
}
