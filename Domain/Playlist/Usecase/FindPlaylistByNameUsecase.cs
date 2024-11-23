using MusicG.Domain.Playlist.Models;
using MusicG.Domain.Playlist.Repository;

namespace MusicG.Domain.Playlist.Usecase;

public class FindPlaylistByNameUsecase
{
    private readonly IPlaylistRepository _repository;

    public FindPlaylistByNameUsecase(IPlaylistRepository repository)
    {
        _repository = repository;
    }

    public Task<List<PlaylistModel>> Invoke(string name)
    {
        return _repository.FindPlaylistByName(name);
    }
}