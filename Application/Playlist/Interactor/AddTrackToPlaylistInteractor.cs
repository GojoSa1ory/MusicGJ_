using AutoMapper;
using MusicG.Domain;
using MusicG.Domain.Playlist.Usecase;

namespace MusicG.Application.Playlist.Interactor;

public class AddTrackToPlaylistInteractor
{
    private readonly AddTrackToPlaylistUsecase _addTrackToPlaylistUsecase;

    public AddTrackToPlaylistInteractor(AddTrackToPlaylistUsecase addTrackToPlaylistUsecase)
    {
        _addTrackToPlaylistUsecase = addTrackToPlaylistUsecase;
    }

    public async Task<ServiceResponse<bool>> Invoke(int trackId, int playlistId, int userId)
    {
        ServiceResponse<bool> res = new();
        
        try
        {
            var req = await _addTrackToPlaylistUsecase.Invoke(trackId: trackId, playlistId: playlistId, userId: userId);
            res.Data = req;
        }
        catch (Exception e)
        {
            res.Err = e.Message;
        }

        return res;
    }
}