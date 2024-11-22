using System.ComponentModel.DataAnnotations.Schema;

namespace MusicG.Infrastructure.database.entity;

[Table("Genre")]
public class GenreEntity
{
    public int Id { get; set; }
    public String Name { get; set; }
}