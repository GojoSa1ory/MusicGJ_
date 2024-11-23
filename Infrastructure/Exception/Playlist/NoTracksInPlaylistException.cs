namespace MusicG.Infrastructure.Exception.Playlist;

public class NoTracksInPlaylistException(string message = "No tracks in playlist"): System.Exception(message){ }