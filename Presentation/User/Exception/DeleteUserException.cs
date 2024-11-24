namespace MusicG.Presentation.User.Exception;

public class DeleteUserException(string mess = "Failed delete user"): System.Exception(mess)
{
    
}