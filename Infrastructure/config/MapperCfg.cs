using AutoMapper;
using MusicG.Application.Auth.DTO;
using MusicG.Application.Genre.Dto;
using MusicG.Application.Playlist.Dto;
using MusicG.Application.User.DTO;
using MusicG.Domain.Auth.Models;
using MusicG.Domain.Genre.Models;
using MusicG.Domain.Playlist.Models;
using MusicG.Domain.Track.Models;
using MusicG.Domain.User;
using MusicG.Infrastructure.database.entity;

namespace MusicG.Infrastructure.config;

public class MapperCfg: Profile
{
    public MapperCfg()
    {
        CreateMap<ResponseUserDto, UserModel>().ReverseMap();
        CreateMap<UserModel, UserEntity>().ReverseMap();
        CreateMap<ResponseUserDto, UserEntity>().ReverseMap();
        
        CreateMap<RequestRegisterAuthDto, AuthModel>().ReverseMap();
        CreateMap<RequestLoginAuthDto, AuthModel>().ReverseMap();
        CreateMap<ResponseUserDto, AuthModel>().ReverseMap();
        CreateMap<AuthModel, UserEntity>().ReverseMap();

        CreateMap<RequestTrackDto, TrackModelWithoutUser>().ReverseMap();
        CreateMap<RequestUpdateTrackDto, TrackModelWithoutUser>().ReverseMap();
        CreateMap<ResponseTrackDto, TrackModel>().ReverseMap();
        CreateMap<TrackEntity, TrackModel>().ReverseMap();
        
        CreateMap<GenreModel, GenreEntity>().ReverseMap();
        CreateMap<GenreModel, ResponseGenreDto>().ReverseMap();

        CreateMap<PlaylistModel, PlaylistEntity>().ReverseMap();
        CreateMap<PlaylistModel, ResponsePlaylistDto>().ReverseMap();
    }
}