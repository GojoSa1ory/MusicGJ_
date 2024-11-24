namespace MusicG.Presentation.Playlist.Exception;

public class CreatePlaylistException(string message = "Failed to create playlist") : System.Exception(message) { }