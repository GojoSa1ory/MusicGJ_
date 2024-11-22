
import 'package:music_g/core/api/api.dart';
import 'package:music_g/core/domain/domain.dart';

TrackModel mapToDomain(ResponseTrackDto track) => TrackModel(name: track.name, trackImage: track.trackImage, track: track.track); 