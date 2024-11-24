using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MusicG.Application.User.DTO;
using MusicG.Application.User.Interactor;
using MusicG.Domain;
using MusicG.Presentation.User.Exception;

namespace MusicG.Presentation.User;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly DeleteUserInteractor _deleteUserInteractor;
    private readonly UpdateUserInteractor _updateUserInteractor;
    private readonly GetUserByIdInteractor _userByIdInteractor;
    private readonly GetUserByUsernameInteractor _byUsernameInteractor;

    public UserController(DeleteUserInteractor deleteUserInteractor, UpdateUserInteractor updateUserInteractor,
        GetUserByIdInteractor userByIdInteractor, GetUserByUsernameInteractor byUsernameInteractor)
    {
        _deleteUserInteractor = deleteUserInteractor;
        _updateUserInteractor = updateUserInteractor;
        _userByIdInteractor = userByIdInteractor;
        _byUsernameInteractor = byUsernameInteractor;
    }

    [HttpGet("/api/user/get/{id}")]
    public async Task<ActionResult<ServiceResponse<ResponseUserDto, String>>> GetUser(int id)
    {
        var res = await _userByIdInteractor.Invoke(id);
        return res.IsSuccess ? Ok(res.DataOrNull) : BadRequest(res.ErrorOrNull);
    }

    [HttpGet("/api/user/get/name/{username}")]
    public async Task<ActionResult<ServiceResponse<ResponseUserDto, String>>> GetUserByUsername(string username)
    {
        var res = await _byUsernameInteractor.Invoke(username);
        return res.IsSuccess ? Ok(res.DataOrNull) : BadRequest(res.ErrorOrNull);
    }

    [Authorize]
    [HttpPatch("/api/user/update")]
    public async Task<ActionResult<ServiceResponse<bool, String>>> UpdateUser(RequestUpdateUserDto dto)
    {
        var value = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (value != null)
        {
            int id = int.Parse(value);
            var res = await _updateUserInteractor.Invoke(dto, id);
            
        }

        return BadRequest(new UpdateUserException().Message);
    }

    [Authorize]
    [HttpDelete("/api/user/delete")]
    public async Task<ActionResult<ServiceResponse<bool, String>>> DeleteUser()
    {
        var value = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (value != null)
        {
            int id = int.Parse(value);
            var res = await _deleteUserInteractor.Invoke(id);
            return res.IsSuccess ? Ok(res.DataOrNull) : BadRequest(res.ErrorOrNull);
        }

        return BadRequest(new DeleteUserException().Message);
    }
}