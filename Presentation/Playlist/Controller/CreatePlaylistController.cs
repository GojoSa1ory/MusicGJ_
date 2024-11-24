using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MusicG.Application.Playlist.Dto;
using MusicG.Application.Playlist.Interactor;
using MusicG.Presentation.Playlist.Exception;

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
        var value = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (value != null)
        {
            int userId = int.Parse(value);
            var resp = await _createPlaylistInteractor.Invoke(dto, userId);
            return resp.IsSuccess ? Ok(resp.DataOrNull) : BadRequest(resp.ErrorOrNull);
        }

        return BadRequest(new CreatePlaylistException().Message);
    }

}