using Microsoft.AspNetCore.Mvc;
using MusicG.Application.Auth.DTO;
using MusicG.Application.Auth.Interactor;
using MusicG.Domain;

namespace MusicG.Presentation.Controller.Auth;

[ApiController]
[Route("[controller]")]
public class LoginAuthController: ControllerBase
{
    private readonly LoginUserInteractor _loginUserInteractor;

    public LoginAuthController(LoginUserInteractor loginUserInteractor)
    {
        _loginUserInteractor = loginUserInteractor;
    }
    
    [HttpPost("/api/auth/login")]
    public async Task<ActionResult<ServiceResponse<ResponseAuthDto, String>>> LoginUser(RequestLoginAuthDto auth)
    {
        var response = await _loginUserInteractor.Invoke(auth);

        return response.IsSuccess ? Ok(response.DataOrNull) : BadRequest(response.ErrorOrNull);
    }
}