using System.Security.Claims;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MusicG.Application.Playlist.Interactor;
using MusicG.Domain;
using MusicG.Presentation.Playlist.Exception;

namespace MusicG.Presentation.Playlist;

[ApiController]
[Route("[controller]")]
public class DeleteTrackFromPlaylistController : ControllerBase
{
    private readonly DeleteTrackFromPlaylistInteractor _fromPlaylistInteractor;

    public DeleteTrackFromPlaylistController(DeleteTrackFromPlaylistInteractor fromPlaylistInteractor)
    {
        _fromPlaylistInteractor = fromPlaylistInteractor;
    }

    [HttpDelete("/api/playlist/{playlistId}/delete/track/{id}")]
    public async Task<ActionResult<ServiceResponse<bool, String>>> Invoke(int playlistId, int id)
    {
        var value = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (value != null)
        {
            int userId = int.Parse(value);
            var res = await _fromPlaylistInteractor.Invoke(trackId: id, userId: userId, playlistId: playlistId);
            return res.IsSuccess ? Ok(res.DataOrNull) : BadRequest(res.ErrorOrNull);
        }

        return BadRequest(new DeleteTrackFromPlaylistException().Message);
    }
}