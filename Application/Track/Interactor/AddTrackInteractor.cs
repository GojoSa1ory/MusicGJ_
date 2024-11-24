
using MusicG.Domain;

public class AddTrackInteractor {
    
    private readonly TrackApplicationMapper _mapper;
    private readonly AddTrackUsecase _usecase;
    private readonly IFileUploadIntrerface _fileUploadUtil;

    public AddTrackInteractor(AddTrackUsecase usecase, TrackApplicationMapper mapper, IFileUploadIntrerface fileUploadUtil)
    {
        _usecase = usecase;
        _mapper = mapper;
        _fileUploadUtil = fileUploadUtil;
    }

    public async Task<ServiceResponse<ResponseTrackDto, String>> Invoke(RequestTrackDto track) {
        try
        {
            var trackPath = await _fileUploadUtil.UploadFile("Track", track.Track);
            var imageTrackPath = await _fileUploadUtil.UploadFile("Image", track.TrackImage);

            var doaminModel = _mapper.MapToDomain(track);

            doaminModel.Track = trackPath;
            doaminModel.TrackImage = imageTrackPath;

            var respModel = await _usecase.Invoke(doaminModel);
            return ServiceResponse<ResponseTrackDto, string>.Success(_mapper.MapToResponse(respModel));
        }
        catch (System.Exception ex)
        {
            return ServiceResponse<ResponseTrackDto, string>.Failure(ex.Message);
        }
    }
}