using AutoMapper;
using MusicG.Application.Playlist.Dto;
using MusicG.Domain;
using MusicG.Domain.Playlist.Usecase;

namespace MusicG.Application.Playlist.Interactor;

public class CreatePlaylistInteractor
{
    private readonly CreatePlaylistUsecase _createPlaylistUsecase;

    public CreatePlaylistInteractor(CreatePlaylistUsecase createPlaylistUsecase)
    {
        _createPlaylistUsecase = createPlaylistUsecase;
    }

    public async Task<ServiceResponse<bool, String>> Invoke(RequestCreatePlaylist dto, int userId)
    {
        try
        {
            var req = await _createPlaylistUsecase.Invoke(dto.Name, userId);
            return ServiceResponse<bool, string>.Success(req);
        }
        catch (Exception e)
        {
            return ServiceResponse<bool, string>.Failure(e.Message);
        }
    }
}