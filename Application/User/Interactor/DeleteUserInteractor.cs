using MusicG.Domain;
using MusicG.Domain.User.Usecases;

namespace MusicG.Application.User.Interactor;

public class DeleteUserInteractor
{
    private readonly DeleteUserUsecase _deleteUserUsecase;

    public DeleteUserInteractor(DeleteUserUsecase deleteUserUsecase)
    {
        _deleteUserUsecase = deleteUserUsecase;
    }

    public async Task<ServiceResponse<bool, String>> Invoke(int id)
    {
        try
        {
            return ServiceResponse<bool, String>.Success(await _deleteUserUsecase.Invoke(id));
        }
        catch (Exception e)
        {
            return ServiceResponse<bool, String>.Failure(e.Message);
        }
    }
}