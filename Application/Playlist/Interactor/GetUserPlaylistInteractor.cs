using AutoMapper;
using MusicG.Application.Playlist.Dto;
using MusicG.Domain;
using MusicG.Domain.Playlist.Usecase;

namespace MusicG.Application.Playlist.Interactor;

public class GetUserPlaylistInteractor
{
    private readonly GetUserPlaylistUseCase _getUserPlaylistUseCase;
    private readonly IMapper _mapper;

    public GetUserPlaylistInteractor(GetUserPlaylistUseCase getUserPlaylistUseCase, IMapper mapper)
    {
        _getUserPlaylistUseCase = getUserPlaylistUseCase;
        _mapper = mapper;
    }

    public async Task<ServiceResponse<List<ResponsePlaylistDto>>> Invoke(int userId)
    {
        ServiceResponse<List<ResponsePlaylistDto>> res = new ServiceResponse<List<ResponsePlaylistDto>>();
        
        try
        {
            var req = await _getUserPlaylistUseCase.Invoke(userId);
            res.Data = req.Select(p => _mapper.Map<ResponsePlaylistDto>(p)).ToList();
        }
        catch (Exception e)
        {
            res.Err = e.Message;
            res.Data = null;
        }
        
        return res;
    }
}