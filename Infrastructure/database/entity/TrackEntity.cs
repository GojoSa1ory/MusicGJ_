using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace MusicG.Infrastructure.database.entity;

[Table(name: "Track_table")]
public class TrackEntity {
    public required int Id {get;set;}
    [Column("name")]
    public required String Name {get;set;}    
    [Column("image")]
    public required String TrackImage {get;set;}    
    [Column("track_link")]
    public required String Track {get;set;}
    [Column("user_id")]
    public required UserEntity User { get; set; }

    public required GenreEntity Genre { get; set; }
    
    public List<PlaylistEntity>? Playlist { get; set; }
}