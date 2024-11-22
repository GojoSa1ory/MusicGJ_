
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
    public async Task<ActionResult<ServiceResponse<ResponseTrackDto>>> AddTrack([FromForm] RequestTrackDto track)
    {
        
        var response = await _addInteractor.Invoke(track);

        if(!response.IsSuccess) return BadRequest(response.err);

        return Ok(response.Data);
    }

}