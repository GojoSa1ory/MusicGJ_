using AutoMapper;
using MusicG.Application.Playlist.Dto;
using MusicG.Domain;
using MusicG.Domain.Playlist.Usecase;

namespace MusicG.Application.Playlist.Interactor;

public class GetPlaylistByIdInteractor
{
    private readonly GetPlaylistByIdUsecase _playlistByIdUsecase;
    private readonly IMapper _mapper;

    public GetPlaylistByIdInteractor(GetPlaylistByIdUsecase playlistByIdUsecase, IMapper mapper)
    {
        _playlistByIdUsecase = playlistByIdUsecase;
        _mapper = mapper;
    }

    public async Task<ServiceResponse<ResponsePlaylistDto>> Invoke(int id)
    {
        ServiceResponse<ResponsePlaylistDto> res = new ServiceResponse<ResponsePlaylistDto>();
        
        try
        {
            var req = await _playlistByIdUsecase.Invoke(id);
            res.Data = _mapper.Map<ResponsePlaylistDto>(req);
        }
        catch (Exception e)
        {
            res.Err = e.Message;
        }

        return res;
    }
}