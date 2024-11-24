using MusicG.Domain;
using MusicG.Domain.Track.Models;

public class UpdateTrackInteractor {
    private readonly TrackApplicationMapper _mapper;
    private readonly UpdateTrackUsecase _usecase;
    private readonly IFileUploadIntrerface _fileUploadUtil;

    public UpdateTrackInteractor(
        TrackApplicationMapper mapper,
        UpdateTrackUsecase usecase,
        IFileUploadIntrerface fileUploadUtil
    ) {
        _mapper = mapper;
        _usecase = usecase;
        _fileUploadUtil = fileUploadUtil;
    }

    public async Task<ServiceResponse<ResponseTrackDto, String>> Invoke(int id, RequestUpdateTrackDto track) {
        try
        {
            var trackPath = await _fileUploadUtil.UploadFile("Track", track.Track);
            var imageTrackPath = await _fileUploadUtil.UploadFile("Image", track.TrackImage);
            
            var doaminModel = _mapper.MapToDomainFromUpdateRequest(track);

            doaminModel.Track = trackPath;
            doaminModel.TrackImage = imageTrackPath;

            var respModel = await _usecase.Invoke(id, doaminModel);
            return ServiceResponse<ResponseTrackDto, string>.Success(_mapper.MapToResponse(respModel));
        }
        catch (System.Exception ex)
        {
            return ServiceResponse<ResponseTrackDto, string>.Failure(ex.Message);
        }
    }
}