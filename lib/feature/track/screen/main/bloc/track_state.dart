part of 'track_bloc.dart';

@immutable
sealed class TrackState {}

final class TrackInitial extends TrackState {}

final class LoadedTrack extends TrackState {
  final String? error;
  final List<TrackModel> tracks;

  LoadedTrack({required this.error, required this.tracks});
}
