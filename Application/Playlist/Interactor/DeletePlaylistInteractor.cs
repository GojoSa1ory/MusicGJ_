using AutoMapper;
using MusicG.Domain;
using MusicG.Domain.Playlist.Usecase;

namespace MusicG.Application.Playlist.Interactor;

public class DeletePlaylistInteractor
{
    private readonly DeletePlaylistUsecase _deletePlaylistUsecase;
    private readonly IMapper _mapper;

    public DeletePlaylistInteractor(DeletePlaylistUsecase deletePlaylistUsecase, IMapper mapper)
    {
        _deletePlaylistUsecase = deletePlaylistUsecase;
        _mapper = mapper;
    }

    public async Task<ServiceResponse<bool, String>> Invoke(int id, int userId)
    {
        try
        {
            var req = await _deletePlaylistUsecase.Invoke(id, userId);
            return ServiceResponse<bool, string>.Success(req);
        }
        catch (Exception e)
        {
            return ServiceResponse<bool, string>.Failure(e.Message);
        }
    }
}