using MusicG.Domain.Track.Models;
using MusicG.Domain.User;

namespace MusicG.Domain.Playlist.Models;

public class PlaylistModel
{
    public required int Id { get; set; }
    public required string Name { get; set; }
    public required string Image { get; set; }
    public required List<TrackModel> Tracks { get; set; }
    public required UserModel User { get; set; }
}