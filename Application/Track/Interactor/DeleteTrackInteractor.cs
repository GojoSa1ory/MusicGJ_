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

    public async Task<ServiceResponse<bool, String>> Invoke(int id)
    {
        try
        {
            await _deleteTrackUsecase.Invoke(id);
            return ServiceResponse<bool, string>.Success(true);
        }
        catch (Exception e)
        {
            return ServiceResponse<bool, string>.Failure(e.Message);
        }
    }
}