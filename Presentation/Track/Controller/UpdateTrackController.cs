using Microsoft.AspNetCore.Mvc;
using MusicG.Domain;

[ApiController]
[Route("[controller]")]
public class UpdateTrackController: ControllerBase {

    private UpdateTrackInteractor _updateInteractor;

    public UpdateTrackController (UpdateTrackInteractor updateInteractor)
    {
        _updateInteractor = updateInteractor;
    }

    [HttpPatch("/api/track/update/{id}")]
    public async Task<ActionResult<ServiceResponse<ResponseTrackDto, string>>> AddTrack([FromForm] RequestUpdateTrackDto track, int id) {
        var res = await _updateInteractor.Invoke(id: id, track: track);
        return res.IsSuccess ? Ok(res.DataOrNull) : BadRequest(res.ErrorOrNull);
    }

}