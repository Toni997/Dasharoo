using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DasharooAPI.Models;

namespace DasharooAPI.Services.Playlists
{
    public interface IPlaylistService
    {
        Task<bool> TryDeleteAndReturnBool(int id);
        Task<ResponseDetails> TryCreateAndReturnResponseDetails(CreatePlaylistDto playlistDto, string authorId);
        Task<ResponseDetails> TryUpdateAndReturnResponseDetails(int id, UpdatePlaylistDto playlistDto);
        Task<IList<PlaylistDto>> GetAllWithRecordsAndAuthor();
        Task<IList<PlaylistForSidebarDto>> GetAllByUserForSidebar(string userId);
        Task<PlaylistDto> GetByIdWithRecordsAndAuthor(int id);
        Task<PlaylistForQueueDto> GetByIdWithRecordsAndAuthorForQueue(int id);
        Task<ResponseDetails> TryAddToPlaylistRecords(int playlistId, int recordId);
    }
}
