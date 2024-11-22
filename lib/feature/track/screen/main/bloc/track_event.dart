part of 'track_bloc.dart';

@immutable
sealed class TrackEvent {}

class LoadTrackEvent extends TrackEvent {}
