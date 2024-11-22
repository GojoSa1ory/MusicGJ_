namespace MusicG.Domain.Track.Models;

public class TrackModelWithoutUser
{
    public required int Id {get;set;}
    public required String Name {get;set;}
    public required String Track {get;set;}
    public required String TrackImage {get;set;}
    public required int UserId { get; set; }
    public required int GenreId { get; set; }
}