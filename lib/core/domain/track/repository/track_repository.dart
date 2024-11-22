import 'package:music_g/core/domain/track/model/track_model.dart';
import 'package:music_g/core/shared/shared.dart';

abstract class TrackRepository {
  Future<Result<List<TrackModel>, String>> getTracks();
}