using Microsoft.AspNetCore.Mvc;
using MusicG.Application.Playlist.Dto;
using MusicG.Application.Playlist.Interactor;
using MusicG.Domain;

namespace MusicG.Presentation.Playlist;

[ApiController]
[Route("[controller]")]
public class GetPlaylistByIdController: ControllerBase
{
    private readonly GetPlaylistByIdInteractor _playlistByIdInteractor;

    public GetPlaylistByIdController(GetPlaylistByIdInteractor playlistByIdInteractor)
    {
        _playlistByIdInteractor = playlistByIdInteractor;
    }


    [HttpGet("/api/playlist/{id}")]
    public async Task<ActionResult<ServiceResponse<ResponsePlaylistDto, string>>> Invoke(int id)
    {
        var res = await _playlistByIdInteractor.Invoke(id);
        
        return res.IsSuccess ? Ok(res.DataOrNull) : BadRequest(res.ErrorOrNull);
    }
}