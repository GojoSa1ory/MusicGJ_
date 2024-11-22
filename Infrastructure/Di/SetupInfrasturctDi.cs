using MusicG.Domain.Auth.Repository;
using MusicG.Domain.User.Repository;
using MusicG.Infrastructure.Mapper;
using MusicG.Infrastructure.Repository;

static class SetupInfrastructureDi
{
    public static void SetupDi(WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<AuthRepository, AuthRepositoryImpl>();
        builder.Services.AddScoped<TrackRepository, TrackRepositoryImpl>();
        builder.Services.AddScoped<UserRepository, UserRepositoryImpl>();

        builder.Services.AddScoped<InfAuthMapper>();
        builder.Services.AddScoped<InfTrackMapper>();
        builder.Services.AddScoped<InfUserMapper, InfUserMapperImpl>();
        builder.Services.AddScoped<InfGenreMapper, InfGenreMapperImpl>();
    }
}