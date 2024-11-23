using MusicG.Application.User.DTO;

namespace MusicG.Application.Playlist.Dto;

public class ResponsePlaylistDto
{
    public required int Id { get; set; }
    public required string Name { get; set; }
    public required string Image { get; set; }
    public required List<ResponseTrackDto> Tracks { get; set; }
    public required ResponseUserDto User { get; set; }
}