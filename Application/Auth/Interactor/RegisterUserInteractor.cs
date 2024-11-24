using MusicG.Application.Auth.DTO;
using MusicG.Application.Auth.Mapper;
using MusicG.Application.Utils;
using MusicG.Domain;
using MusicG.Domain.Auth.Usecases;

namespace MusicG.Application.Auth.Interactor;

public class RegisterUserInteractor
{
    private RegisterUserUseCase _registerUserUseCase;
    private ApplicationAuthMapper _mapper;
    private IConfiguration _configuration;
    private readonly IJwtTokenGenerate _jwtTokenGenerate;
    
    public RegisterUserInteractor (
        RegisterUserUseCase registerUserUseCase, 
        ApplicationAuthMapper mapper, 
        IConfiguration configuration,
        IJwtTokenGenerate jwtTokenGenerate
    ) {
        _registerUserUseCase = registerUserUseCase;
        _mapper = mapper;
        _configuration = configuration;
        _jwtTokenGenerate = jwtTokenGenerate;
    }

    public async Task<ServiceResponse<ResponseAuthDto, String>> Invoke(RequestRegisterAuthDto reg)
    {
        try
        {
            var requestAuthModel = _mapper.MapRegisterRequestToDomain(reg);

            var responseAuthModel = await _registerUserUseCase.Invoke(requestAuthModel);
            
            string token = _jwtTokenGenerate.GenerateToken(responseAuthModel.DataOrNull, _configuration);
            return ServiceResponse<ResponseAuthDto, string>.Success(_mapper.MapToResponse(responseAuthModel.DataOrNull, token));
        }
        catch (Exception e)
        {
            return ServiceResponse<ResponseAuthDto, string>.Failure(e.Message);
        }
        
    }
    
}