
namespace MusicG.Infrastructure.Exception.User;


public class UserAlreadyExistException(string message = "User with same email already exist"): System.Exception (message);