using MusicG.Domain;

public class GetTrackByIdInteractor {

    private readonly GetTrackByIdUsecase _getTrackById;
    private readonly TrackApplicationMapper _mapper;

    public GetTrackByIdInteractor(GetTrackByIdUsecase getTrackById, TrackApplicationMapper mapper)
    {
        _getTrackById = getTrackById;
        _mapper = mapper;
    }

    public async Task<ServiceResponse<ResponseTrackDto>> Invoke(int id) {

        ServiceResponse<ResponseTrackDto> resp = new();

        try
        {
            var data = await _getTrackById.Invoke(id);
            resp.Data = _mapper.MapToResponse(data);
        }
        catch (Exception ex)
        {
            resp.err = ex.Message;
        }
        
        return resp;
    }
}