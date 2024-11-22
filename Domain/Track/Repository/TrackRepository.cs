using MusicG.Domain.Track.Models;

public interface TrackRepository {
    Task<TrackModel> AddTrack(TrackModelWithoutUser track);
    Task<List<TrackModel>> GetTracks();
    Task<TrackModel> GetTrackById(int id);
    Task<List<TrackModel>> GetTrackByName(String name);
    Task<TrackModel> UpdateTrack(int id, TrackModel track);
    Task DeleteTrack(int id);
}