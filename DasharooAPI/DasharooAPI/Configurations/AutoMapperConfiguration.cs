using AutoMapper;
using DasharooAPI.Data;
using DasharooAPI.Models;

namespace DasharooAPI.Configurations
{
    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, SignupUserDto>().ReverseMap();
            CreateMap<User, LoginUserDto>().ReverseMap();
            CreateMap<User, UserOnRecordDto>();
            CreateMap<User, GetUserDto>();
            CreateMap<UpdateUserDto, User>();

            CreateMap<Record, RecordDto>().ReverseMap();
            CreateMap<Record, CreateRecordDto>().ReverseMap();
            CreateMap<Record, UpdateRecordDto>().ReverseMap();
            CreateMap<Record, RecordForQueueDto>();
            CreateMap<Record, RecordForSearchDto>();


            CreateMap<Playlist, PlaylistDto>().ReverseMap();
            CreateMap<Playlist, CreatePlaylistDto>().ReverseMap();
            CreateMap<Playlist, UpdatePlaylistDto>().ReverseMap();
            CreateMap<Playlist, PlaylistForQueueDto>();
            CreateMap<Playlist, PlaylistForSidebarDto>();

            CreateMap<Genre, GenreDto>().ReverseMap();
            CreateMap<Genre, GenreOnRecordDto>().ReverseMap();
            CreateMap<Genre, CreateGenreDto>().ReverseMap();
            CreateMap<Genre, UpdateGenreDto>().ReverseMap();

            // junction tables
            CreateMap<RecordGenre, RecordGenreDto>();
            CreateMap<RecordGenre, RecordGenreOnRecordDto>();
            CreateMap<RecordAuthor, RecordAuthorDto>();
            CreateMap<RecordPlaylist, RecordPlaylistDto>();
        }
    }
}
