using Microsoft.AspNetCore.Mvc;
using MusicG.Domain;

[ApiController]
[Route("[controller]")]
public class GetTrackByIdController: ControllerBase {

    private readonly GetTrackByIdInteractor _interactor;
    public GetTrackByIdController(GetTrackByIdInteractor interactor) {
        _interactor = interactor;
    }

    [HttpPost("api/track/get")]
    public async Task<ActionResult<ServiceResponse<ResponseTrackDto>>> GetTrackById(int id) {
        var res = await _interactor.Invoke(id);

        if(!res.IsSuccess) return BadRequest(res.err);

        return Ok(res.Data);
    }
}