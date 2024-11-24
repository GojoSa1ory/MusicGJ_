
import 'package:dio/dio.dart';
import 'package:music_g/core/api/auth/dto/request_auth_dto.dart';
import 'package:music_g/core/api/auth/dto/response_auth_dto.dart';
import 'package:music_g/core/api/utils/links.dart';
import 'package:music_g/core/api/utils/network_error.dart';
import 'package:music_g/core/shared/shared.dart' show Result;

class LoginUserRequests {

  final Dio _http;

  const LoginUserRequests(this._http);

  Future<Result<ResponseAuthDto, String>> invoke({required RequestAuthDto auth}) async {

    try {
      final req = await _http.post(
          RequestsLinks.loginLink.getLink(),
          options: Options(
            contentType: Headers.jsonContentType,
          ),
          data: auth.toJson()
      );

      final Map<String, dynamic> data = req.data;

      return Result.success(ResponseAuthDto.fromJson(data));
    } on DioException catch(e) {

      if(e.response?.statusCode == 400) {
        return Result.failure(NetworkError.BAD_REQUEST_ERROR.name);
      } else if(e.response?.statusCode == 500) {
        return Result.failure(NetworkError.SERVER_ERROR.name);
      } else {
        return Result.failure(NetworkError.UNKNOW_ERROR.name);
      }
    } catch (e) {
      return Result.failure(e.toString());
    }


  }

}

