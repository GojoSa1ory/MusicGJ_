using MusicG.Application.Auth.Interactor;
using MusicG.Application.Auth.Mapper;
using MusicG.Application.Playlist.Interactor;
using MusicG.Application.Track.Interactor;
using MusicG.Application.Utils;
using MusicG.Domain.Playlist.Usecase;
using MusicG.Domain.Track.Usecase;

static class SetupApplicationDi
{
    public static void SetupDi(WebApplicationBuilder builder)
    {

        builder.Services.AddScoped<ApplicationAuthMapper>();
        builder.Services.AddScoped<TrackApplicationMapper>();

        builder.Services.AddScoped<LoginUserInteractor>();
        builder.Services.AddScoped<RegisterUserInteractor>();

        builder.Services.AddScoped<AddTrackInteractor>();
        builder.Services.AddScoped<GetTrackByIdInteractor>();
        builder.Services.AddScoped<UpdateTrackInteractor>();
        builder.Services.AddScoped<DeleteTrackInteractor>();
        builder.Services.AddScoped<GetTracksInteractor>();
        
        builder.Services.AddScoped<IFileUploadIntrerface, FileUploadUtil>();
        builder.Services.AddScoped<IJwtTokenGenerate, JwtTokenGenerateImpl>();
        
        builder.Services.AddScoped<CreatePlaylistInteractor>();
        builder.Services.AddScoped<GetUserPlaylistInteractor>();
        builder.Services.AddScoped<AddTrackToPlaylistInteractor>();
        builder.Services.AddScoped<DeleteTrackFromPlaylistInteractor>();
        builder.Services.AddScoped<FindPlaylistByNameInteractor>();
        builder.Services.AddScoped<GetPlaylistByIdInteractor>();
        builder.Services.AddScoped<DeletePlaylistInteractor>();
    }
}