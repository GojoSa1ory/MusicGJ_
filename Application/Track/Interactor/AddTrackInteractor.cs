
using MusicG.Domain;

public class AddTrackInteractor {
    
    private readonly TrackApplicationMapper _mapper;
    private readonly AddTrackUsecase _usecase;
    private readonly FileUploadIntrerface _fileUploadUtil;

    public AddTrackInteractor(AddTrackUsecase usecase, TrackApplicationMapper mapper, FileUploadIntrerface fileUploadUtil)
    {
        _usecase = usecase;
        _mapper = mapper;
        _fileUploadUtil = fileUploadUtil;
    }

    public async Task<ServiceResponse<ResponseTrackDto>> Invoke(RequestTrackDto track) {

        ServiceResponse<ResponseTrackDto> resp = new();

        try
        {
            var trackPath = await _fileUploadUtil.UploadFile("Track", track.Track);
            var imageTrackPath = await _fileUploadUtil.UploadFile("Image", track.TrackImage);

            var doaminModel = _mapper.MapToDomain(track);

            doaminModel.Track = trackPath;
            doaminModel.TrackImage = imageTrackPath;

            var respModel = await _usecase.Invoke(doaminModel);
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