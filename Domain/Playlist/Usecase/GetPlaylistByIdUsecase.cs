using MusicG.Domain.Playlist.Models;
using MusicG.Domain.Playlist.Repository;

namespace MusicG.Domain.Playlist.Usecase;

public class GetPlaylistByIdUsecase
{
    private readonly IPlaylistRepository _repository;

    public GetPlaylistByIdUsecase(IPlaylistRepository repository)
    {
        _repository = repository;
    }

    public Task<PlaylistModel> Invoke(int id)
    {
        return _repository.GetPlaylistById(id);
    }
}