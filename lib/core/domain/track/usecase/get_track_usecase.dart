import 'package:music_g/core/domain/track/model/track_model.dart';
import 'package:music_g/core/domain/track/repository/track_repository.dart';
import 'package:music_g/core/shared/result.dart';

class GetTrackUsecase {
  final TrackRepository _rep;

  GetTrackUsecase({required TrackRepository rep}) : _rep = rep;

  Future<Future<Result<List<TrackModel>, String>>> invoke() async {
    return _rep.getTracks();
  }

}