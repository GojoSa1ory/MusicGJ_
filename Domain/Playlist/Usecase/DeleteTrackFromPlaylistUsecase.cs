using MusicG.Domain.Playlist.Repository;

namespace MusicG.Domain.Playlist.Usecase;

public class DeleteTrackFromPlaylistUsecase
{
    private readonly IPlaylistRepository _repository;

    public DeleteTrackFromPlaylistUsecase(IPlaylistRepository repository)
    {
        _repository = repository;
    }

    public Task<bool> Invoke(int trackId, int playlistId, int userId)
    {
        return _repository.DeleteTrackFromPlaylist(trackId, playlistId, userId);
    }
}