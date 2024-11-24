using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MusicG.Application.Playlist.Dto;
using MusicG.Application.Playlist.Interactor;
using MusicG.Domain;
using MusicG.Presentation.Playlist.Exception;

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
    public async Task<ActionResult<ServiceResponse<List<ResponsePlaylistDto>, String>>> GetUserPlaylist()
    {
        var value = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (value != null)
        {
            int userId = int.Parse(value);
            var res = await _userPlaylistInteractor.Invoke(userId: userId);
            return res.IsSuccess ? Ok(res.DataOrNull) : BadRequest(res.ErrorOrNull);
        }

        return BadRequest(new GetUserPlaylistException().Message);
    }

    [HttpGet("api/get/playlist/user/{id}")]
    public async Task<ActionResult<ServiceResponse<List<ResponsePlaylistDto>, String>>> GetUserPlaylistById(int id)
    {
        var res = await _userPlaylistInteractor.Invoke(userId: id);
        return res.IsSuccess ? Ok(res.DataOrNull) : BadRequest(res.ErrorOrNull);
    }
}