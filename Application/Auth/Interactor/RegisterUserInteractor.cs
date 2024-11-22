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
    private readonly JwtTokenGenerate _jwtTokenGenerate;
    
    public RegisterUserInteractor (
        RegisterUserUseCase registerUserUseCase, 
        ApplicationAuthMapper mapper, 
        IConfiguration configuration,
        JwtTokenGenerate jwtTokenGenerate
    ) {
        _registerUserUseCase = registerUserUseCase;
        _mapper = mapper;
        _configuration = configuration;
        _jwtTokenGenerate = jwtTokenGenerate;
    }

    public async Task<ServiceResponse<ResponseAuthDto>> invoke(RequestRegisterAuthDto reg)
    {
        ServiceResponse<ResponseAuthDto> res = new();
        
        try
        {
            var requestAuthModel = _mapper.MapRegisterRequestToDomain(reg);

            var responseAuthModel = await _registerUserUseCase.invoke(requestAuthModel);

            if (!responseAuthModel.IsSuccess)
            {
                res.err = responseAuthModel.err;
                return res;
            }
            
            string token = _jwtTokenGenerate.GenerateToken(responseAuthModel.Data, _configuration);
            res.Data = _mapper.MapToResponse(responseAuthModel.Data, token);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            res.err = e.Message;
            throw;
        }
        
        return res;
    }
    
}