namespace MusicG.Infrastructure.Exception.Playlist;

public class PlaylistNotFound(string message = "Playlist not found"): System.Exception(message){ }