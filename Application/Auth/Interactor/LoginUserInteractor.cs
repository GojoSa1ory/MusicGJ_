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
    private readonly IJwtTokenGenerate _jwtTokenGenerate;

    public LoginUserInteractor(
        LoginUserUseCase loginUserUseCase,
        ApplicationAuthMapper mapper,
        IConfiguration configuration,
        IJwtTokenGenerate jwtTokenGenerate
    ) {
        _loginUserUseCase = loginUserUseCase;
        _mapper = mapper;
        _configuration = configuration;
        _jwtTokenGenerate = jwtTokenGenerate;
    }
    
    public async Task<ServiceResponse<ResponseAuthDto, String>> Invoke(RequestLoginAuthDto reg)
    {
        try
        {
            var authReqModel = _mapper.MapLoginRequestToDomain(reg);
            var autResponseLogin =  await _loginUserUseCase.Invoke(authReqModel);

            string token = _jwtTokenGenerate.GenerateToken(autResponseLogin.DataOrNull, _configuration);
            return ServiceResponse<ResponseAuthDto,String>.Success( _mapper.MapToResponse(autResponseLogin.DataOrNull, token));
        }
        catch (Exception ex)
        {
            return ServiceResponse<ResponseAuthDto, string>.Failure(ex.Message);
        }
        
    }
}