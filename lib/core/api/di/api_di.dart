import 'package:dio/dio.dart';
import 'package:get_it/get_it.dart';
import 'package:music_g/core/api/auth/requests/login_user_requests.dart';
import 'package:music_g/core/api/auth/requests/register_user_request.dart';
import 'package:music_g/core/api/track/track.dart';

void setupApiDi() {
  GetIt.instance.registerSingleton<Dio>(Dio());

  final Dio dio = GetIt.instance.get<Dio>();

  GetIt.instance.registerSingleton<LoginUserRequests>(LoginUserRequests(dio));
  GetIt.instance.registerSingleton<RegisterUserRequest>(RegisterUserRequest(dio));

  GetIt.instance.registerSingleton<GetTracksRequest>(GetTracksRequest(dio));

}