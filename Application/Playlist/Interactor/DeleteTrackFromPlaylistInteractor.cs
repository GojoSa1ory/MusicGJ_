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

    public async Task<ServiceResponse<bool, string>> Invoke(int trackId, int playlistId, int userId)
    {
        try
        {
            var req = await _fromPlaylistUsecase.Invoke(trackId, playlistId, userId);
            return ServiceResponse<bool, string>.Success(req);
        }
        catch (Exception e)
        {
            return ServiceResponse<bool, string>.Failure(e.Message);
        }
    }
}