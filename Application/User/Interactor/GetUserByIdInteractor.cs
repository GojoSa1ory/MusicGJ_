using AutoMapper;
using MusicG.Application.User.DTO;
using MusicG.Domain;
using MusicG.Domain.User.Usecases;

namespace MusicG.Application.User.Interactor;

public class GetUserByIdInteractor
{
    private readonly GetUserByIdUseCase _useCase;
    private readonly IMapper _mapper;
    
    public GetUserByIdInteractor(GetUserByIdUseCase useCase, IMapper mapper)
    {
        _useCase = useCase;
        _mapper = mapper;
    }

    public async Task<ServiceResponse<ResponseUserDto, String>> Invoke(int id)
    {
        try
        {
            var req = await _useCase.Invoke(id);
            return ServiceResponse<ResponseUserDto, string>.Success(_mapper.Map<ResponseUserDto>(req));
        }
        catch (Exception e)
        {
            return ServiceResponse<ResponseUserDto, string>.Failure(e.Message);
        }
    }
}