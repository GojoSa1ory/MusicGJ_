using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using MusicG.Application.Playlist.Interactor;
using MusicG.Domain;

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
    public async Task<ActionResult<ServiceResponse<bool>>> Invoke(int playlistId, int id)
    {
        int userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
        var res = await _fromPlaylistInteractor.Invoke(trackId: id, userId: userId, playlistId: playlistId);
        if (!res.IsSuccess) return BadRequest(res.Err);
        return Ok(res.Data);
    }
}