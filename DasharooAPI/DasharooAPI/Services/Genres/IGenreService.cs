using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DasharooAPI.Models;

namespace DasharooAPI.Services.Genres
{
    public interface IGenreService
    {
        Task<bool> TryDeleteAndReturnBool(int id);
        Task<ResponseDetails> TryCreateAndReturnResponseDetails(CreateGenreDto genreDto);
        Task<ResponseDetails> TryUpdateAndReturnResponseDetails(int id, UpdateGenreDto genreDto);
        Task<IList<GenreDto>> GetAll();
        Task<GenreDto> GetById(int id);
        Task<GenreDto> GetByIdWithRecords(int id);
    }
}
