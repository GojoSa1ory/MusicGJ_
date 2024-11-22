using MusicG.Domain;
using MusicG.Domain.Track.Models;
using MusicG.Domain.Track.Usecase;

namespace MusicG.Application.Track.Interactor;

public class GetTracksInteractor
{
    private readonly GetTracksUsecase _usecase;
    private readonly TrackApplicationMapper _mapper;

    public GetTracksInteractor(GetTracksUsecase usecase, TrackApplicationMapper mapper)
    {
        _usecase = usecase;
        _mapper = mapper;
    }

    public async Task<ServiceResponse<List<ResponseTrackDto>>> Invoke()
    {
        ServiceResponse < List < ResponseTrackDto >> resp = new();
        
        try
        {
            List<TrackModel> tracks = await _usecase.Invoke();
            resp.Data = tracks.Select(t => _mapper.MapToResponse(t)).ToList();
        }
        catch (Exception e)
        {
            resp.err = e.Message;
        }

        return resp;
    }
}