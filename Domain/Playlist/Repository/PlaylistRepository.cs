using MusicG.Domain.Playlist.Models;

namespace MusicG.Domain.Playlist.Repository;

public interface IPlaylistRepository
{
    Task<bool> CreatePlaylist(string name, int userId);
    Task<bool> DeletePlaylist(int id, int userId);
    Task<bool> AddTrackToPlaylist(int trackId, int playlistId, int userId);
    Task<bool> DeleteTrackFromPlaylist(int trackId, int playlistId, int userId);
    Task<PlaylistModel> GetPlaylistById(int id);
    Task<List<PlaylistModel>> GetUserPlaylist(int userId);
    Task<List<PlaylistModel>> FindPlaylistByName(string name);
}