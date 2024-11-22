import 'package:json/json.dart';

@JsonCodable()
class ResponseTrackDto { 
  final String name;
  final String trackImage;
  final String track;

  ResponseTrackDto({required this.name, required this.trackImage, required this.track});

  ResponseTrackDto copyWith(String? name, String? trackImage, String? track) => ResponseTrackDto(name: name ?? this.name, trackImage: trackImage ?? this.trackImage, track: track ?? this.track);
}