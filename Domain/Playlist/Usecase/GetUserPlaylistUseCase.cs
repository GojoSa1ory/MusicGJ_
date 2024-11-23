using MusicG.Domain.Playlist.Models;
using MusicG.Domain.Playlist.Repository;

namespace MusicG.Domain.Playlist.Usecase;

public class GetUserPlaylistUseCase
{
    private readonly IPlaylistRepository _rep;

    public GetUserPlaylistUseCase(IPlaylistRepository rep)
    {
        _rep = rep;
    }

    public Task<List<PlaylistModel>> Invoke(int userId)
    {
        return _rep.GetUserPlaylist(userId: userId);
    }
}