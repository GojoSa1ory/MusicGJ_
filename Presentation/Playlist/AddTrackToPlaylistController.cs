using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using MusicG.Application.Playlist.Interactor;
using MusicG.Domain;

namespace MusicG.Presentation.Playlist;

[ApiController]
[Route("[controller]")]
public class AddTrackToPlaylistController: ControllerBase
{
    private AddTrackToPlaylistInteractor _toPlaylistInteractor;

    public AddTrackToPlaylistController(AddTrackToPlaylistInteractor toPlaylistInteractor)
    {
        _toPlaylistInteractor = toPlaylistInteractor;
    }

    [HttpPost("/api/playlist/{playlistId}/add/track/{id}")]
    public async Task<ActionResult<ServiceResponse<bool>>> Invoke(int playlistId, int id)
    {
        int userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
        var res = await _toPlaylistInteractor.Invoke(trackId: id, playlistId: playlistId, userId: userId);

        if (!res.IsSuccess) return BadRequest(res.Err);

        return Ok(res.Data);
    }
}