using MusicG.Application.Auth.Interactor;
using MusicG.Application.Auth.Mapper;
using MusicG.Application.Track.Interactor;
using MusicG.Application.Utils;
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

        builder.Services.AddScoped<FileUploadIntrerface, FileUploadUtil>();
        builder.Services.AddScoped<JwtTokenGenerate, JwtTokenGenerateImpl>();
    }
}