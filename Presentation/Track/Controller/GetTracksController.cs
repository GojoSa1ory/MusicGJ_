using Microsoft.AspNetCore.Mvc;
using MusicG.Application.Track.Interactor;
using MusicG.Domain;

namespace MusicG.Presentation.Track.Controller;

[ApiController]
[Route("[controller]")]
public class GetTracksController: ControllerBase
{
    
    private readonly GetTracksInteractor _tracksInteractor;

    public GetTracksController(GetTracksInteractor tracksInteractor)
    {
        _tracksInteractor = tracksInteractor;
    }


    [HttpGet("/api/tracks/all")]
    public async Task<ActionResult<ServiceResponse<List<ResponseTrackDto>>>> GetTracks()
    {
        var res = await _tracksInteractor.Invoke();

        if (!res.IsSuccess) return BadRequest(res.err);

        return Ok(res.Data);
    }
    
}