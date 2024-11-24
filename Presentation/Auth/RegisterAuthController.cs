using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MusicG.Application.Auth.DTO;
using MusicG.Application.Auth.Interactor;
using MusicG.Domain;

namespace MusicG.Presentation.Controller.Auth;

[ApiController]
[Route("[controller]")]
public class RegisterAuthController: ControllerBase
{
    private RegisterUserInteractor _registerUserInteractor;
    
    public RegisterAuthController(RegisterUserInteractor registerUserInteractor)
    {
        _registerUserInteractor = registerUserInteractor;
    }

    [HttpPost("/api/auth/register")]
    public async Task<ActionResult<ServiceResponse<ResponseAuthDto, String>>> RegisterUser(RequestRegisterAuthDto auth)
    {
        var res = await _registerUserInteractor.Invoke(auth);

        return res.IsSuccess ? Ok(res.DataOrNull) : BadRequest(res.DataOrNull);
    }
}