using System.Security.Claims;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MusicG.Application.Playlist.Interactor;
using MusicG.Domain;
using MusicG.Presentation.Playlist.Exception;

namespace MusicG.Presentation.Playlist;

[ApiController]
[Route("[controller]")]
public class DeletePlaylistController: ControllerBase
{
    private readonly DeletePlaylistInteractor _deletePlaylistInteractor;

    public DeletePlaylistController(DeletePlaylistInteractor deletePlaylistInteractor)
    {
        _deletePlaylistInteractor = deletePlaylistInteractor;
    }

    [HttpDelete("/api/playlist/delete/{id}")]
    public async Task<ActionResult<ServiceResponse<bool, String>>> Invoke(int id)
    {
        var value = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (value != null)
        {
            int userId = int.Parse(value);
            var res = await _deletePlaylistInteractor.Invoke(id, userId);
            return res.IsSuccess ? Ok(res.DataOrNull) : BadRequest(res.ErrorOrNull);
        }

        return BadRequest(new DeletePlaylistException().Message);
    }
}