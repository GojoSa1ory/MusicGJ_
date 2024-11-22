import 'package:get_it/get_it.dart';
import 'package:music_g/core/api/api.dart';
import 'package:music_g/core/data/data.dart';
import 'package:music_g/core/domain/domain.dart';

void setupDataDi() {
  GetIt.instance.registerFactory<AuthRepository>(() => AuthRepositoryImpl(
      GetIt.instance.get<LoginUserRequests>(), GetIt.instance.get<RegisterUserRequest>()
    )
  );
  GetIt.instance.registerFactory<TrackRepository>(() => TrackRepositoryImpl(getTracksRequest: GetIt.instance.get<GetTracksRequest>()));
}
