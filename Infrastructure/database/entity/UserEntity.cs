using System.ComponentModel.DataAnnotations.Schema;

namespace MusicG.Infrastructure.database.entity;

[Table(name: "Users_table")]
public class UserEntity
{
    public int Id { get; set; }
    public string username { get; set; }
    public string email { get; set; }
    public string password { get; set; }
    public List<TrackEntity> tracks { get; set; }
}