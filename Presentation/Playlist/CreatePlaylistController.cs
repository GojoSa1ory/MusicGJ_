using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MusicG.Application.Playlist.Dto;
using MusicG.Application.Playlist.Interactor;

namespace MusicG.Presentation.Playlist;

[ApiController]
[Route("[controller]")]
public class CreatePlaylistController: ControllerBase
{
    private readonly CreatePlaylistInteractor _createPlaylistInteractor;

    public CreatePlaylistController(CreatePlaylistInteractor createPlaylistInteractor)
    {
        _createPlaylistInteractor = createPlaylistInteractor;
    }

    [Authorize]
    [HttpPost("/api/create/playlist")]
    public async Task<ActionResult<bool>> Invoke(RequestCreatePlaylist dto)
    {
        int userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
        var resp = await _createPlaylistInteractor.Invoke(dto, userId);
        if (!resp.IsSuccess) return BadRequest();
        return Ok(resp);
    }

}