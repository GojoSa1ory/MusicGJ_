using MusicG.Domain.Genre.Models;
using MusicG.Domain.User;

namespace MusicG.Domain.Track.Models;

public class TrackModel {
    
    public required int Id {get;set;}
    public required String Name {get;set;}
    public required String Track {get;set;}
    public required String TrackImage {get;set;}
    public required UserModel User { get; set; }
    public required GenreModel Genre { get; set; }
}