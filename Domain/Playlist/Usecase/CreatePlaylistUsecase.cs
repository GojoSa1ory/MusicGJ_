using MusicG.Domain.Playlist.Repository;

namespace MusicG.Domain.Playlist.Usecase;

public class CreatePlaylistUsecase
{
    private readonly IPlaylistRepository _rep;

    public CreatePlaylistUsecase(IPlaylistRepository rep)
    {
        this._rep = rep;
    }

    public Task<bool> Invoke(string name, int userId)
    {
        return _rep.CreatePlaylist(name: name, userId: userId);
    }
}