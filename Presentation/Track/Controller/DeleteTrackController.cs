using Microsoft.AspNetCore.Mvc;
using MusicG.Application.Track.Interactor;
using MusicG.Domain;

namespace MusicG.Presentation.Track.Controller;

[ApiController]
[Route("[controller]")]
public class DeleteTrackController: ControllerBase
{
    private readonly DeleteTrackInteractor _deleteTrackInteractor;

    public DeleteTrackController(DeleteTrackInteractor deleteTrackInteractor)
    {
        _deleteTrackInteractor = deleteTrackInteractor;
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ServiceResponse<string, string>>> DeleteTrack(int id)
    {
        var res = await _deleteTrackInteractor.Invoke(id);
        return res.IsSuccess ? Ok(res.DataOrNull) : BadRequest(res.ErrorOrNull);
    }
}