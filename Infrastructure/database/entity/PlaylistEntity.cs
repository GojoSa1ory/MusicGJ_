using System.ComponentModel.DataAnnotations.Schema;

namespace MusicG.Infrastructure.database.entity;

[Table(name: "Playlist")]
public class PlaylistEntity
{
    [Column("id")]
    public required int Id { get; set; }
    
    [Column("name")]
    public required string Name { get; set; }
    
    [Column("image")]
    public required string Image { get; set; }
    
    public required List<TrackEntity>? Tracks { get; set; }
    
    public required UserEntity User { get; set; }
}