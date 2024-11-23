using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using MusicG.Application.Playlist.Interactor;
using MusicG.Domain;

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
    public async Task<ActionResult<ServiceResponse<bool>>> Invoke(int id)
    {
        int userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
        var res = await _deletePlaylistInteractor.Invoke(id, userId);

        if (!res.IsSuccess) return BadRequest(res.Err);

        return Ok(res.Data);
    }
}