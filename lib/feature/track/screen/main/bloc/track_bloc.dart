import 'package:bloc/bloc.dart';
import 'package:get_it/get_it.dart';
import 'package:meta/meta.dart';
import 'package:music_g/core/domain/domain.dart';

part 'track_event.dart';
part 'track_state.dart';

class TrackBloc extends Bloc<TrackEvent, TrackState> {

  TrackBloc() : super(TrackInitial()) {

    on<LoadTrackEvent>((event, emit)  async {

      final TrackRepository rep = GetIt.I.get<TrackRepository>();
      final data = await rep.getTracks();

      data.onSuccess((data) {
        emit(LoadedTrack(error: null, tracks: data));
      });
      data.onError((err) => emit(LoadedTrack(error: err, tracks: const [])));
    });

  }
}
