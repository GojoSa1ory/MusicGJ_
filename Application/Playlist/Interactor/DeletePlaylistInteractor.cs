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

    public async Task<ServiceResponse<bool>> Invoke(int id, int userId)
    {
        ServiceResponse<bool> res = new();
        
        try
        {
            var req = _deletePlaylistUsecase.Invoke(id, userId);
            res.Data = req.Result;
        }
        catch (Exception e)
        {
            res.Err = e.Message;
        }

        return res;
    }
}