using Microsoft.EntityFrameworkCore;
using MusicG.Infrastructure.database.entity;

namespace MusicG.Infrastructure.database;

public class AppDatabaseContext(DbContextOptions<AppDatabaseContext> options) : DbContext(options)
{
    public DbSet<UserEntity> Users { get; set; }
    public DbSet<TrackEntity> Tracks { get; set; }
    public DbSet<GenreEntity> Genres { get; set; }
    public DbSet<PlaylistEntity> Playlist { get; set; }
    
}