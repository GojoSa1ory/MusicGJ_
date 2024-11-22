using MusicG.Domain;
using MusicG.Domain.Track.Usecase;

namespace MusicG.Application.Track.Interactor;

public class DeleteTrackInteractor
{
    private readonly DeleteTrackUsecase _deleteTrackUsecase;

    public DeleteTrackInteractor(DeleteTrackUsecase deleteTrackUsecase)
    {
        _deleteTrackUsecase = deleteTrackUsecase;
    }

    public async Task<ServiceResponse<String>> Invoke(int id)
    {
        ServiceResponse<String> resp = new();
        
        try
        {
            await _deleteTrackUsecase.Invoke(id);
            resp.Data = "Success";
        }
        catch (Exception e)
        {
            resp.Data = null;
            resp.err = e.Message;
        }

        return resp;
    }
}