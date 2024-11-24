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

    public async Task<ServiceResponse<ResponsePlaylistDto, String>> Invoke(int id)
    {
        try
        {
            var req = await _playlistByIdUsecase.Invoke(id);
            return ServiceResponse<ResponsePlaylistDto, string>.Success(_mapper.Map<ResponsePlaylistDto>(req));
        }
        catch (Exception e)
        {
            return ServiceResponse<ResponsePlaylistDto, string>.Failure(e.Message);
        }
    }
}