using MusicG.Domain;
using MusicG.Domain.Track.Models;

public class UpdateTrackInteractor {
    private readonly TrackApplicationMapper _mapper;
    private readonly UpdateTrackUsecase _usecase;
    private readonly FileUploadIntrerface _fileUploadUtil;

    public UpdateTrackInteractor(
        TrackApplicationMapper mapper,
        UpdateTrackUsecase usecase,
        FileUploadIntrerface fileUploadUtil
    ) {
        _mapper = mapper;
        _usecase = usecase;
        _fileUploadUtil = fileUploadUtil;
    }

    public async Task<ServiceResponse<ResponseTrackDto>> Invoke(int id, RequestUpdateTrackDTO track) {

        ServiceResponse<ResponseTrackDto> resp = new();
        try
        {
            var trackPath = await _fileUploadUtil.UploadFile("Track", track.Track);
            var imageTrackPath = await _fileUploadUtil.UploadFile("Image", track.TrackImage);
            
            var doaminModel = _mapper.MapToDomainFromUpdateRequest(track);

            doaminModel.Track = trackPath;
            doaminModel.TrackImage = imageTrackPath;

            var respModel = await _usecase.Invoke(id, doaminModel);
            resp.Data = _mapper.MapToResponse(respModel);
        }
        catch (System.Exception ex)
        {
            resp.Data = null;
            resp.err = ex.Message;
        }

        return resp;

    }
}