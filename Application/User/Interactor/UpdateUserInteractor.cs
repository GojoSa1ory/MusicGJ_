using AutoMapper;
using MusicG.Application.User.DTO;
using MusicG.Domain;
using MusicG.Domain.User;
using MusicG.Domain.User.Usecases;

namespace MusicG.Application.User.Interactor;

public class UpdateUserInteractor
{
    private readonly UpdateUserUsecase _updateUserUsecase;
    private readonly IMapper _mapper;

    public UpdateUserInteractor(UpdateUserUsecase updateUserUsecase, IMapper mapper)
    {
        _updateUserUsecase = updateUserUsecase;
        _mapper = mapper;
    }

    public async Task<ServiceResponse<bool>> Invoke(RequestUpdateUserDto dto, int id)
    {
        ServiceResponse<bool> res = new();

        try
        {
            var userToUpdateModel = _mapper.Map<UserToUpdateModel>(dto);
            res.Data = await _updateUserUsecase.Invoke(userToUpdateModel, id);
        }
        catch (Exception e)
        {
            res.Err = e.Message;
        }
        
        return res;
    }
}