using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using MusicG.Application.Playlist.Interactor;
using MusicG.Domain;
using MusicG.Presentation.Playlist.Exception;

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
    public async Task<ActionResult<ServiceResponse<bool, String>>> Invoke(int playlistId, int id)
    {
        var value = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (value != null)
        {
            int userId = int.Parse(value);
            var res = await _toPlaylistInteractor.Invoke(trackId: id, playlistId: playlistId, userId: userId);
            return res.IsSuccess ? Ok(res.DataOrNull) : BadRequest(res.ErrorOrNull);
        }

        return BadRequest(new FailedToAddTrackException().Message);
    }
}