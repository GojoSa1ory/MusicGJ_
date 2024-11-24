using MusicG.Domain;

public class GetTrackByIdInteractor {

    private readonly GetTrackByIdUsecase _getTrackById;
    private readonly TrackApplicationMapper _mapper;

    public GetTrackByIdInteractor(GetTrackByIdUsecase getTrackById, TrackApplicationMapper mapper)
    {
        _getTrackById = getTrackById;
        _mapper = mapper;
    }

    public async Task<ServiceResponse<ResponseTrackDto, string>> Invoke(int id) {
        try
        {
            var data = await _getTrackById.Invoke(id);
            return ServiceResponse<ResponseTrackDto, string>.Success(_mapper.MapToResponse(data));
        }
        catch (Exception ex)
        {
            return ServiceResponse<ResponseTrackDto, string>.Failure(ex.Message);
        }
    }
}