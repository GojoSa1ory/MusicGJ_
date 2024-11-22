namespace MusicG.Infrastructure.Exception.Auth;

public class LoginFailedException(string message = "Invalid password or login. Check your data please"): System.Exception(message);