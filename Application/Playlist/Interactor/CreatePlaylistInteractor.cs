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

    public async Task<ServiceResponse<bool>> Invoke(RequestCreatePlaylist dto, int userId)
    {
        ServiceResponse<bool> res = new();
        
        try
        {
            var req = await _createPlaylistUsecase.Invoke(dto.Name, userId);
            res.Data = req;
        }
        catch (Exception e)
        {
            res.Data = false;
            res.Err = e.Message;
        }

        return res;
    }
}