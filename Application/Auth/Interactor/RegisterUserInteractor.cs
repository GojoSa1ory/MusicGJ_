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

    public async Task<ServiceResponse<ResponseAuthDto>> Invoke(RequestRegisterAuthDto reg)
    {
        ServiceResponse<ResponseAuthDto> res = new();
        
        try
        {
            var requestAuthModel = _mapper.MapRegisterRequestToDomain(reg);

            var responseAuthModel = await _registerUserUseCase.Invoke(requestAuthModel);

            if (!responseAuthModel.IsSuccess)
            {
                res.Err = responseAuthModel.Err;
                return res;
            }
            
            string token = _jwtTokenGenerate.GenerateToken(responseAuthModel.Data, _configuration);
            res.Data = _mapper.MapToResponse(responseAuthModel.Data, token);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            res.Err = e.Message;
            throw;
        }
        
        return res;
    }
    
}