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

    public Task<ServiceResponse<ResponseUserDto, String>> Invoke(string username)
    {
        try
        {
            var user = _useCase.Invoke(username: username);
            return Task.FromResult(ServiceResponse<ResponseUserDto, String>.Success(_mapper.Map<ResponseUserDto>(user.Result)));
        }
        catch (Exception e)
        {
            return Task.FromResult(ServiceResponse<ResponseUserDto, String>.Failure(e.Message));
        }
    }
}