using AutoMapper;
using MusicG.Application.User.DTO;
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

    public async Task<ServiceResponse<bool>> Invoke(int id)
    {
        ServiceResponse<bool> res = new ServiceResponse<bool>();
        
        try
        {
            res.Data = await _deleteUserUsecase.Invoke(id);;
        }
        catch (Exception e)
        {
            res.Err = e.Message;
        }

        return res;
    }
}