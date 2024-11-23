using MusicG.Domain.Playlist.Repository;

namespace MusicG.Domain.Playlist.Usecase;

public class DeletePlaylistUsecase
{
    private readonly IPlaylistRepository _rep;

    public DeletePlaylistUsecase(IPlaylistRepository rep)
    {
        _rep = rep;
    }

    public Task<bool> Invoke(int id, int userId)
    {
        return _rep.DeletePlaylist(id, userId);
    }
}