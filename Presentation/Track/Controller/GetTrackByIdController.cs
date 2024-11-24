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
    public async Task<ActionResult<ServiceResponse<ResponseTrackDto, string>>> GetTrackById(int id) {
        var res = await _interactor.Invoke(id);

        return res.IsSuccess ? Ok(res.DataOrNull) : BadRequest(res.ErrorOrNull);
    }
}