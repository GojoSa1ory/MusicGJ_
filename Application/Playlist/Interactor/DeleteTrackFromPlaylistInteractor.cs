using MusicG.Domain;
using MusicG.Domain.Playlist.Usecase;

namespace MusicG.Application.Playlist.Interactor;

public class DeleteTrackFromPlaylistInteractor
{
    private readonly DeleteTrackFromPlaylistUsecase _fromPlaylistUsecase;

    public DeleteTrackFromPlaylistInteractor(DeleteTrackFromPlaylistUsecase fromPlaylistUsecase)
    {
        _fromPlaylistUsecase = fromPlaylistUsecase;
    }

    public async Task<ServiceResponse<bool>> Invoke(int trackId, int playlistId, int userId)
    {
        ServiceResponse<bool> res = new();

        try
        {
            var req = await _fromPlaylistUsecase.Invoke(trackId, playlistId, userId);
            res.Data = req;
        }
        catch (Exception e)
        {
            res.Err = e.Message;
        }
        
        return res;
    }
}