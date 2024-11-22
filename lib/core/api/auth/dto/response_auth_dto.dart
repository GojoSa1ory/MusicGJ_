import 'package:json/json.dart';
import 'package:music_g/core/api/user/user.dart';


@JsonCodable()
class ResponseAuthDto {

  final UserDto user;
  final String token;

  const ResponseAuthDto({
    required this.user,
    required this.token
  });
}
