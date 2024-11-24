
using Microsoft.AspNetCore.Mvc;
using MusicG.Domain;
using MusicG.Domain.Track.Models;

[ApiController]
[Route("[controller]")]
public class AddTrackController: ControllerBase {

    private AddTrackInteractor _addInteractor;

    public AddTrackController (AddTrackInteractor addInteractor)
    {
        _addInteractor = addInteractor;
    }

    [HttpPost("api/track/add")]
    public async Task<ActionResult<ServiceResponse<ResponseTrackDto, string>>> AddTrack([FromForm] RequestTrackDto track)
    {
        var res = await _addInteractor.Invoke(track);
        return res.IsSuccess ? Ok(res.DataOrNull) : BadRequest(res.ErrorOrNull);
    }

}