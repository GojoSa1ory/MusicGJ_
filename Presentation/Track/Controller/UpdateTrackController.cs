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
    public async Task<ActionResult<ServiceResponse<ResponseTrackDto>>> AddTrack([FromForm] RequestUpdateTrackDTO track, int id) {
        var response = await _updateInteractor.Invoke(id: id, track: track);

        if(!response.IsSuccess) return BadRequest(response.err);

        return Ok(response.Data);
    }

}