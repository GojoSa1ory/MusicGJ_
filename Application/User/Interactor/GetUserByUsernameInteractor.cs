using AutoMapper;
using MusicG.Application.User.DTO;
using MusicG.Domain;
using MusicG.Domain.User.Usecases;

namespace MusicG.Application.User.Interactor;

public class GetUserByUsernameInteractor
{
    private readonly GetUserByUsernameUseCase _useCase;
    private readonly IMapper _mapper;

    public GetUserByUsernameInteractor(GetUserByUsernameUseCase useCase, IMapper mapper)
    {
        _useCase = useCase;
        _mapper = mapper;
    }

    public Task<ServiceResponse<ResponseUserDto>> Invoke(string username)
    {
        ServiceResponse<ResponseUserDto> res = new ServiceResponse<ResponseUserDto>();

        try
        {
            var user = _useCase.Invoke(username: username);
            res.Data = _mapper.Map<ResponseUserDto>(user.Result);
        }
        catch (Exception e)
        {
            res.Err = e.Message;
        }
        
        return Task.FromResult(res);
    }
}