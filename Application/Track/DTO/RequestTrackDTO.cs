public class RequestTrackDto {
    public String Name {get; set;}
    public IFormFile TrackImage {get; set;}
    public IFormFile Track {get; set;}
    public int UserId { get; set; }
    public int GenreId { get; set; }
}