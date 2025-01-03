using MusicG.Domain.Auth.Usecases;
using MusicG.Domain.Playlist.Usecase;
using MusicG.Domain.Track.Usecase;
using MusicG.Domain.User.Usecases;

static class SetupDomainDi {
    public static void SetupDi(WebApplicationBuilder builder) {

        builder.Services.AddScoped<RegisterUserUseCase>();
        builder.Services.AddScoped<LoginUserUseCase>();

        builder.Services.AddScoped<DeleteUserUsecase>();
        builder.Services.AddScoped<UpdateUserUsecase>();
        builder.Services.AddScoped<GetUserByUsernameUseCase>();
        builder.Services.AddScoped<GetUserByIdUseCase>();
        
        
        builder.Services.AddScoped<AddTrackUsecase>();
        builder.Services.AddScoped<GetTrackByIdUsecase>();
        builder.Services.AddScoped<UpdateTrackUsecase>();
        builder.Services.AddScoped<DeleteTrackUsecase>();
        builder.Services.AddScoped<GetTracksUsecase>();
        builder.Services.AddScoped<GetTrackByNameUsecase>();
        
        
        builder.Services.AddScoped<CreatePlaylistUsecase>();
        builder.Services.AddScoped<GetUserPlaylistUseCase>();
        builder.Services.AddScoped<AddTrackToPlaylistUsecase>();
        builder.Services.AddScoped<DeletePlaylistUsecase>();
        builder.Services.AddScoped<DeleteTrackFromPlaylistUsecase>();
        builder.Services.AddScoped<FindPlaylistByNameUsecase>();
        builder.Services.AddScoped<GetPlaylistByIdUsecase>();
    }
}