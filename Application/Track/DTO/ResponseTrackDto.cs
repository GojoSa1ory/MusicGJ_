using MusicG.Application.Genre.Dto;
using MusicG.Application.User.DTO;

public class ResponseTrackDto {
    public int Id {get;set;}
    public String Name {get;set;}
    public String Track {get;set;}
    public String TrackImage {get;set;}
    public ResponseUserDto User { get; set; }
    public ResponseGenreDto Genre { get; set; }
}