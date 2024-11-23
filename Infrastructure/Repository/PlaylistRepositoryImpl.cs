using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MusicG.Domain.Playlist.Models;
using MusicG.Domain.Playlist.Repository;
using MusicG.Infrastructure.database;
using MusicG.Infrastructure.database.entity;
using MusicG.Infrastructure.Exception.Playlist;
using MusicG.Infrastructure.Exception.User;

namespace MusicG.Infrastructure.Repository;

public class PlaylistRepositoryImpl: IPlaylistRepository
{
    private readonly AppDatabaseContext _database;
    private readonly IMapper _mapper;

    public PlaylistRepositoryImpl(AppDatabaseContext database, IMapper mapper)
    {
        _database = database;
        _mapper = mapper;
    }

    public async Task<bool> CreatePlaylist(string name, int userId)
    {
        var user = _database.Users.FirstOrDefault(u => u.Id == userId);
        if (user is null) throw new UserNotFoundException();
        PlaylistEntity playlistEntity = new PlaylistEntity
        {
            Id = 0,
            Image = "",
            User = user,
            Tracks = null,
            Name = name
        };

        _database.Playlist.Add(playlistEntity);
        await _database.SaveChangesAsync();

        return true;
    }

    public async Task<bool> DeletePlaylist(int id, int userId)
    {
        var playlist = _database.Playlist.FirstOrDefault(p => p.Id == id && p.User.Id == userId);
        if (playlist is null) throw new System.Exception("Not found");
        _database.Playlist.Remove(playlist);
        await _database.SaveChangesAsync();
        return true;
    }

    public async Task<bool> AddTrackToPlaylist(int trackId, int playlistId, int userId)
    {
        var track = _database.Tracks
            .Include(t => t.Genre)
            .Include(t => t.User)
            .FirstOrDefault(t => t.Id == trackId);

        if (track is null) throw new TrackNotFoundException();
        
        var playlist = _database.Playlist
            .Include(p => p.User)
            .FirstOrDefault(p => p.Id == playlistId && p.User.Id == userId);
        
        if (playlist is null) throw new PlaylistNotFound();

        playlist.Tracks = new List<TrackEntity> { track };
        
        await _database.SaveChangesAsync();

        return true;
    }

    public async Task<bool> DeleteTrackFromPlaylist(int trackId, int playlistId, int userId)
    {
        var track = _database.Tracks
            .Include(t => t.Genre)
            .Include(t => t.User)
            .FirstOrDefault(t => t.Id == trackId);

        if (track is null) throw new TrackNotFoundException();
        
        var playlist = _database.Playlist
            .Include(p => p.User)
            .Include(playlistEntity => playlistEntity.Tracks)
            .FirstOrDefault(p => p.Id == playlistId && p.User.Id == userId);
        
        if (playlist is null) throw new PlaylistNotFound();
        
        if (playlist.Tracks.IsNullOrEmpty()) throw new NoTracksInPlaylistException();

        playlist.Tracks!.Remove(track);
        
        await _database.SaveChangesAsync();

        return true;
    }

    public async Task<PlaylistModel> GetPlaylistById(int id)
    {
        var playlist = _database.Playlist
            .Include(p => p.Tracks)!
                .ThenInclude(t => t.Genre)
            .Include(p => p.User)
            .FirstOrDefault(p => p.Id == id);
        if (playlist is null) throw new PlaylistNotFound();

        return _mapper.Map<PlaylistModel>(playlist);
    }

    public async Task<List<PlaylistModel>> GetUserPlaylist(int userId)
    {
        var playlists = _database.Playlist
            .Include(p => p.Tracks)
                .ThenInclude(t => t.Genre)
            .Include(p => p.User)
            .Where(p => p.User.Id == userId).ToList();
        if (playlists.IsNullOrEmpty()) throw new System.Exception("Not found");
        return playlists.Select(p => _mapper.Map<PlaylistModel>(p)).ToList();
    }

    public async Task<List<PlaylistModel>> FindPlaylistByName(string name)
    {
        var playlist = _database.Playlist
            .Include(p => p.Tracks)!
            .ThenInclude(t => t.Genre)
            .Include(p => p.User)
            .Where(p => p.Name.ToLower().Contains(name));
        
        if (playlist.IsNullOrEmpty()) throw new PlaylistNotFound();

        return playlist.Select(p => _mapper.Map<PlaylistModel>(p)).ToList();
    }
}