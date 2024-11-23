using AutoMapper;
using MusicG.Application.Playlist.Dto;
using MusicG.Domain;
using MusicG.Domain.Playlist.Usecase;

namespace MusicG.Application.Playlist.Interactor;

public class FindPlaylistByNameInteractor
{
    private readonly FindPlaylistByNameUsecase _playlistByNameUsecase;
    private readonly IMapper _mapper;

    public FindPlaylistByNameInteractor(FindPlaylistByNameUsecase playlistByNameUsecase, IMapper mapper)
    {
        _playlistByNameUsecase = playlistByNameUsecase;
        _mapper = mapper;
    }
    
    public async Task<ServiceResponse<List<ResponsePlaylistDto>>> Invoke (string name)
    {
        ServiceResponse<List<ResponsePlaylistDto>> res = new();

        try
        {
            var req = await _playlistByNameUsecase.Invoke(name);
            res.Data = req.Select(p => _mapper.Map<ResponsePlaylistDto>(p)).ToList();
        }
        catch (Exception e)
        {
            res.Err = e.Message;
        }
        
        return res;
    }
}