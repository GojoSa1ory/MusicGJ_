using System.ComponentModel.DataAnnotations.Schema;

namespace MusicG.Infrastructure.database.entity;

[Table(name: "Users_table")]
public class UserEntity
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    
    public List<TrackEntity> Tracks { get; set; }
    
    public List<PlaylistEntity>? Playlists { get; set; }
}