import 'package:dio/dio.dart';
import 'package:music_g/core/api/track/track.dart';
import 'package:music_g/core/api/utils/links.dart';
import 'package:music_g/core/api/utils/network_error.dart';
import 'package:music_g/core/shared/shared.dart';

class GetTracksRequest {

  final Dio _http;

  GetTracksRequest(this._http);

  Future<Result<List<ResponseTrackDto>, String>> getTracks() async {
    try {

      final resp = await _http.get(RequestsLinks.getTracks.getLink());
      final List<ResponseTrackDto> mappedData = (resp.data as List).map((t) => ResponseTrackDto.fromJson(t)).toList();
      final List<ResponseTrackDto> result = mappedData.map((el) => el.copyWith(null, el.trackImage.replaceFirst("localhost", "10.0.2.2"), el.track.replaceFirst("localhost", "10.0.2.2"))).toList();

      return Result.success(result);

    } on DioException catch (err) {

      if(err.response?.statusCode == 400) {
        return Result.failure(NetworkError.BAD_REQUEST_ERROR.name);
      } else if (err.response?.statusCode == 500) {
        return Result.failure(NetworkError.SERVER_ERROR.name);
      } else if (err.response?.statusCode == 503) {
        return Result.failure(NetworkError.SERVER_ERROR.name);
      } else {
        return Result.failure(NetworkError.UNKNOW_ERROR.name);
      }
    } catch(err) {
      return Result.failure(NetworkError.UNKNOW_ERROR.name);
    }
  }

}