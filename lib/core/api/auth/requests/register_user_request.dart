import 'package:dio/dio.dart';
import 'package:music_g/core/api/auth/dto/request_auth_dto.dart';
import 'package:music_g/core/api/auth/dto/response_auth_dto.dart';
import 'package:music_g/core/api/utils/network_error.dart';

import '../../../shared/shared.dart' show Result;
import '../../utils/links.dart';

class RegisterUserRequest {
  final Dio _http;

  const RegisterUserRequest(this._http);

  Future<Result<ResponseAuthDto, String>> invoke({required RequestAuthDto auth}) async {

    try {
      final req = await _http.post(
          RequestsLinks.registerLink.getLink(),
          options: Options(
            contentType: Headers.jsonContentType,
          ),
          data: auth.toJson()
      );

      print(req.data['data'].toString());

      return Result.success(ResponseAuthDto.fromJson(req.data as Map<String, dynamic>));
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
