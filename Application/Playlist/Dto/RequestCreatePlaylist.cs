namespace MusicG.Application.Playlist.Dto;

public class RequestCreatePlaylist
{
    public required string Name { get;set; }
    public IFormFile? Image { get; set; }
}