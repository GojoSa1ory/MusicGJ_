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

    public async Task<ServiceResponse<bool, String>> Invoke(int trackId, int playlistId, int userId)
    {
        try
        {
            var req = await _addTrackToPlaylistUsecase.Invoke(trackId: trackId, playlistId: playlistId, userId: userId);
            return ServiceResponse<bool, string>.Success(req);
        }
        catch (Exception e)
        {
            return ServiceResponse<bool, string>.Failure(e.Message);
        }
    }
}