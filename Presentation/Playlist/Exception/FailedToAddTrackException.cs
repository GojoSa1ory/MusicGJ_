namespace MusicG.Presentation.Playlist.Exception;

public class FailedToAddTrackException(string message = "Failed add track to playlist") : System.Exception(message) { }