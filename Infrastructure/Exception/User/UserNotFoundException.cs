namespace MusicG.Infrastructure.Exception.User;

public class UserNotFoundException(string message = "User not found"): System.Exception(message);