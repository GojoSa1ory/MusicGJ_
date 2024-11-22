using MusicG.Application.Auth.DTO;
using MusicG.Application.Auth.Mapper;
using MusicG.Application.Utils;
using MusicG.Domain;
using MusicG.Domain.Auth.Usecases;

namespace MusicG.Application.Auth.Interactor;

public class LoginUserInteractor
{
    private readonly LoginUserUseCase _loginUserUseCase;
    private readonly ApplicationAuthMapper _mapper;
    private readonly IConfiguration _configuration;
    private readonly JwtTokenGenerate _jwtTokenGenerate;

    public LoginUserInteractor(
        LoginUserUseCase loginUserUseCase,
        ApplicationAuthMapper mapper,
        IConfiguration configuration,
        JwtTokenGenerate jwtTokenGenerate
    ) {
        _loginUserUseCase = loginUserUseCase;
        _mapper = mapper;
        _configuration = configuration;
        _jwtTokenGenerate = jwtTokenGenerate;
    }
    
    public async Task<ServiceResponse<ResponseAuthDto>> invoke(RequestLoginAuthDto reg)
    {
        ServiceResponse<ResponseAuthDto> res = new();

        try
        {
            var authReqModel = _mapper.MapLoginRequestToDomain(reg);
            var autResponseLogin =  await _loginUserUseCase.invoke(authReqModel);

            if (autResponseLogin.Data == null) throw new Exception("Login failed");

            string token = _jwtTokenGenerate.GenerateToken(autResponseLogin.Data, _configuration);
            res.Data = _mapper.MapToResponse(autResponseLogin.Data, token);
        }
        catch (Exception ex)
        {
            res.err = ex.Message;
        }
        
        return res;
    }
}