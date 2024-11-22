import 'package:music_g/core/api/api.dart';
import 'package:music_g/core/data/track/mapper/data_track_mapper.dart';
import 'package:music_g/core/domain/track/model/track_model.dart';
import 'package:music_g/core/domain/track/track.dart' show TrackRepository;
import 'package:music_g/core/shared/result.dart';

class TrackRepositoryImpl implements TrackRepository{

  final GetTracksRequest _getTracksRequest;

  TrackRepositoryImpl({required GetTracksRequest getTracksRequest}) : _getTracksRequest = getTracksRequest;

  @override
  Future<Result<List<TrackModel>, String>> getTracks() async {

    final res = await _getTracksRequest.getTracks();
    late final List<TrackModel> tracks;

    res.onSuccess((data) {
      tracks = data.map((el) => mapToDomain(el)).toList();
    });
    
    return res.isSuccess ? Result.success(tracks) : Result.failure(res.errorOrNull.toString());
  }

}