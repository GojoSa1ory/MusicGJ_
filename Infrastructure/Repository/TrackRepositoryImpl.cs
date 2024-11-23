using Microsoft.IdentityModel.Tokens;
using MusicG.Domain.Track.Models;
using MusicG.Infrastructure.database;
using MusicG.Infrastructure.database.entity;
using MusicG.Infrastructure.Exception.User;

namespace MusicG.Infrastructure.Repository;

public class TrackRepositoryImpl(
    AppDatabaseContext db,
    InfTrackMapper mapper) : ITrackRepository
{
    public async Task<TrackModel> AddTrack(TrackModelWithoutUser track)
    {
        var user = db.Users.FirstOrDefault(u => u.Id == track.UserId);
        if (user == null) throw new UserNotFoundException();

        var genre = db.Genres.FirstOrDefault(g => g.Id == track.GenreId);
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

        db.Tracks.Add(entity);
        await db.SaveChangesAsync();
        return mapper.MapToDomain(entity);
    }


    public async Task<List<TrackModel>> GetTracks()
    {
        return db.Tracks.Select(t => mapper.MapToDomain(t)).ToList();
    }

    public async Task<TrackModel> UpdateTrack(int id, TrackModel model)
    {
        var track = db.Tracks.First(t => t.Id == id);

        Console.WriteLine(model);

        if (track is null) throw new TrackNotFoundException();

        track.Name = model.Name == track.Name ? track.Name : model.Name;
        track.Track = model.Track == track.Track ? track.Track : model.Track;
        track.TrackImage = model.TrackImage == track.TrackImage ? track.TrackImage : model.TrackImage;

        await db.SaveChangesAsync();
        var resp = mapper.MapToDomain(track);

        return resp;
    }

    public async Task<TrackModel> GetTrackById(int id)
    {
        var track = db.Tracks.FirstOrDefault(track => track.Id == id);

        if (track is null)
        {
            throw new System.Exception("Track not found");
        }

        return mapper.MapToDomain(track);
    }

    public async Task<List<TrackModel>> GetTrackByName(string name)
    {
        var track = db.Tracks.Where(t => t.Name == name).Select(t => mapper.MapToDomain(t)).ToList();
        if (track.IsNullOrEmpty()) throw new TrackNotFoundException();
        return track;
    }


    public async Task DeleteTrack(int id)
    {
        var dbTrack = db.Tracks.FirstOrDefault(t => t.Id == id);
        if (dbTrack is null)
            throw new TrackNotFoundException();

        db.Tracks.Remove(dbTrack);
        await db.SaveChangesAsync();
    }
}

