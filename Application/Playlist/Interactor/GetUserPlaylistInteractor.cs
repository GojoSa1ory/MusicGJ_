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

    public async Task<ServiceResponse<List<ResponsePlaylistDto>, string>> Invoke(int userId)
    {
        try
        {
            var req = await _getUserPlaylistUseCase.Invoke(userId);
            return ServiceResponse<List<ResponsePlaylistDto>, string>.Success(req.Select(p => _mapper.Map<ResponsePlaylistDto>(p)).ToList());
        }
        catch (Exception e)
        {
            return ServiceResponse<List<ResponsePlaylistDto>, string>.Failure(e.Message);
        }
    }
}