using Microsoft.AspNetCore.Mvc;
using MusicG.Application.Playlist.Dto;
using MusicG.Domain;

namespace MusicG.Application.Playlist.Interactor;

[ApiController]
[Route("[controller]")]
public class FindPlaylistByNameController: ControllerBase
{
    private readonly FindPlaylistByNameInteractor _playlistByNameInteractor;

    public FindPlaylistByNameController(FindPlaylistByNameInteractor playlistByNameInteractor)
    {
        _playlistByNameInteractor = playlistByNameInteractor;
    }

    [HttpGet("/api/playlist/find/{name}")]
    public async Task<ActionResult<ServiceResponse<List<ResponsePlaylistDto>>>> Invoke(string name)
    {
        var res = await _playlistByNameInteractor.Invoke(name);

        if(!res.IsSuccess) return BadRequest(res.Err);
        
        return Ok(res.Data);
    }
}