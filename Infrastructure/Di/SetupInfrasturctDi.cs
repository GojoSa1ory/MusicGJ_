using MusicG.Domain.Auth.Repository;
using MusicG.Domain.Playlist.Repository;
using MusicG.Domain.User.Repository;
using MusicG.Infrastructure.Mapper;
using MusicG.Infrastructure.Repository;

static class SetupInfrastructureDi
{
    public static void SetupDi(WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IAuthRepository, AuthRepositoryImpl>();
        builder.Services.AddScoped<ITrackRepository, TrackRepositoryImpl>();
        builder.Services.AddScoped<IUserRepository, UserRepositoryImpl>();

        builder.Services.AddScoped<InfAuthMapper>();
        builder.Services.AddScoped<InfTrackMapper>();
        builder.Services.AddScoped<INfUserMapper, InfUserMapperImpl>();
        builder.Services.AddScoped<INfGenreMapper, InfGenreMapperImpl>();
        
        builder.Services.AddScoped<IPlaylistRepository, PlaylistRepositoryImpl>();
    }
}