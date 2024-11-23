using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MusicG.Application.Playlist.Dto;
using MusicG.Application.Playlist.Interactor;
using MusicG.Domain;

namespace MusicG.Presentation.Playlist;

[ApiController]
[Route("[controller]")]
public class GetUserPlaylistController: ControllerBase
{

    private readonly GetUserPlaylistInteractor _userPlaylistInteractor;

    public GetUserPlaylistController(GetUserPlaylistInteractor userPlaylistInteractor)
    {
        _userPlaylistInteractor = userPlaylistInteractor;
    }

    [Authorize]
    [HttpGet("/api/get/playlist")]
    public async Task<ActionResult<ServiceResponse<List<ResponsePlaylistDto>>>> Invoke()
    {
        int userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
        var res = await _userPlaylistInteractor.Invoke(userId: userId);
        if (!res.IsSuccess) return BadRequest(res.Err);
        return Ok(res.Data);
    }

    [HttpGet("api/get/playlist/user/{id}")]
    public async Task<ActionResult<ServiceResponse<List<ResponsePlaylistDto>>>> Get(int id)
    {
        var res = await _userPlaylistInteractor.Invoke(userId: id);
        if (!res.IsSuccess) return BadRequest(res.Err);
        return Ok(res.Data);
    }
}