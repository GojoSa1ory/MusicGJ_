using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MusicG.Application.User.DTO;
using MusicG.Application.User.Interactor;
using MusicG.Domain;

namespace MusicG.Presentation.User;

[ApiController]
[Route("[controller]")]
public class UserController: ControllerBase
{
    private readonly DeleteUserInteractor _deleteUserInteractor;
    private readonly UpdateUserInteractor _updateUserInteractor;
    private readonly GetUserByIdInteractor _userByIdInteractor;
    private readonly GetUserByUsernameInteractor _byUsernameInteractor;

    public UserController(DeleteUserInteractor deleteUserInteractor, UpdateUserInteractor updateUserInteractor, GetUserByIdInteractor userByIdInteractor, GetUserByUsernameInteractor byUsernameInteractor)
    {
        _deleteUserInteractor = deleteUserInteractor;
        _updateUserInteractor = updateUserInteractor;
        _userByIdInteractor = userByIdInteractor;
        _byUsernameInteractor = byUsernameInteractor;
    }

    [HttpGet("/api/user/get/{id}")]
    public async Task<ActionResult<ServiceResponse<ResponseUserDto>>> GetUser(int id)
    {
        var res = await _userByIdInteractor.Invoke(id);
        if (!res.IsSuccess) return BadRequest(res.Err);
        return Ok(res.Data);
    }

    [HttpGet("/api/user/get/name/{username}")]
    public async Task<ActionResult<ServiceResponse<ResponseUserDto>>> GetUserByUsername(string username)
    {
        var res = await _byUsernameInteractor.Invoke(username);
        if (!res.IsSuccess) return BadRequest(res.Err);
        return Ok(res.Data);
    }

    [Authorize]
    [HttpPatch("/api/user/update")]
    public async Task<ActionResult<ServiceResponse<bool>>> UpdateUser(RequestUpdateUserDto dto)
    {
        var value = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        
        if (value != null)
        {
            int id = int.Parse(value);
            var res = await _updateUserInteractor.Invoke(dto, id);
            if (!res.IsSuccess) return BadRequest(res.Err);
            return Ok(res.Data);
        }

        return BadRequest("Something wrong");
    }

    [Authorize]
    [HttpDelete("/api/user/delete")]
    public async Task<ActionResult<ServiceResponse<bool>>> DeleteUser()
    {
        var value = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (value != null)
        {
            int id = int.Parse(value);
            var res = await _deleteUserInteractor.Invoke(id);
            if (!res.IsSuccess) return BadRequest(res.Err);
            return Ok(res.Data);
        }
        
        return BadRequest("Something wrong");
    }
}