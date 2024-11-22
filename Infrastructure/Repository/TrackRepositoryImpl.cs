using Microsoft.IdentityModel.Tokens;
using MusicG.Domain.Track.Models;
using MusicG.Infrastructure.database;
using MusicG.Infrastructure.database.entity;
using MusicG.Infrastructure.Exception.User;

namespace MusicG.Infrastructure.Repository;

public class TrackRepositoryImpl(
    AppDatabaseContext _db,
    InfTrackMapper _mapper) : TrackRepository
{
    public async Task<TrackModel> AddTrack(TrackModelWithoutUser track)
    {
        var user = _db.Users.FirstOrDefault(u => u.Id == track.UserId);
        if (user == null) throw new UserNotFoundException();

        var genre = _db.Genres.FirstOrDefault(g => g.Id == track.GenreId);
        if (genre == null) throw new System.Exception("Genre not found");

        var entity = new TrackEntity
        {
            Id = 0,
            Name = track.Name,
            TrackImage = track.TrackImage,
            Track = track.Track,
            User = user,
            Genre = genre
        };

        _db.Tracks.Add(entity);
        await _db.SaveChangesAsync();
        return _mapper.MapToDomain(entity);
    }


    public async Task<List<TrackModel>> GetTracks()
    {
        return _db.Tracks.Select(t => _mapper.MapToDomain(t)).ToList();
    }

    public async Task<TrackModel> UpdateTrack(int id, TrackModel model)
    {
        var track = _db.Tracks.First(t => t.Id == id);

        Console.WriteLine(model);

        if (track is null) throw new TrackNotFoundException();

        track.Name = model.Name == track.Name ? track.Name : model.Name;
        track.Track = model.Track == track.Track ? track.Track : model.Track;
        track.TrackImage = model.TrackImage == track.TrackImage ? track.TrackImage : model.TrackImage;

        await _db.SaveChangesAsync();
        var resp = _mapper.MapToDomain(track);

        return resp;
    }

    public async Task<TrackModel> GetTrackById(int id)
    {
        var track = _db.Tracks.FirstOrDefault(track => track.Id == id);

        if (track is null)
        {
            throw new System.Exception("Track not found");
        }

        return _mapper.MapToDomain(track);
    }

    public async Task<List<TrackModel>> GetTrackByName(string name)
    {
        var track = _db.Tracks.Where(t => t.Name == name).Select(t => _mapper.MapToDomain(t)).ToList();
        if (track.IsNullOrEmpty()) throw new TrackNotFoundException();
        return track;
    }


    public async Task DeleteTrack(int id)
    {
        var dbTrack = _db.Tracks.FirstOrDefault(t => t.Id == id);
        if (dbTrack is null)
            throw new TrackNotFoundException();

        _db.Tracks.Remove(dbTrack);
        await _db.SaveChangesAsync();
    }
}


