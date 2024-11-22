using MusicG.Domain.Auth.Usecases;
using MusicG.Domain.Track.Usecase;

static class SetupDomainDi {
    public static void SetupDi(WebApplicationBuilder builder) {

        builder.Services.AddScoped<RegisterUserUseCase>();
        builder.Services.AddScoped<LoginUserUseCase>();

        builder.Services.AddScoped<AddTrackUsecase>();
        builder.Services.AddScoped<GetTrackByIdUsecase>();
        builder.Services.AddScoped<UpdateTrackUsecase>();
        builder.Services.AddScoped<DeleteTrackUsecase>();
        builder.Services.AddScoped<GetTracksUsecase>();
    }
}