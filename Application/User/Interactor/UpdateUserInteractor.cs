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

    public async Task<ServiceResponse<bool, String>> Invoke(RequestUpdateUserDto dto, int id)
    {

        try
        {
            var userToUpdateModel = _mapper.Map<UserToUpdateModel>(dto);
            return ServiceResponse<bool, string>.Success(await _updateUserUsecase.Invoke(userToUpdateModel, id));
        }
        catch (Exception e)
        {
            return ServiceResponse<bool, string>.Failure(e.Message);
        }
        
    }
}