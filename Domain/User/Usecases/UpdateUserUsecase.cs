using MusicG.Domain.User.Repository;

namespace MusicG.Domain.User.Usecases;

public class UpdateUserUsecase
{
    private IUserRepository _rep;

    public UpdateUserUsecase(IUserRepository rep)
    {
        _rep = rep;
    }

    public Task<bool> Invoke(UserToUpdateModel user,int id)
    {
        return _rep.UpdateUser(user, id);
    }
}