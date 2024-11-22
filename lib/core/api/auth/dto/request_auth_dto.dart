import 'package:json/json.dart';

@JsonCodable()
class RequestAuthDto {

  final String username;
  final String email;
  final String password;

  RequestAuthDto({
    required this.username,
    required this.email,
    required this.password
  });

}
