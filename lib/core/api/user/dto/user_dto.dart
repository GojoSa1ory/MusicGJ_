import 'package:json/json.dart';

@JsonCodable()
class UserDto {
  final int id;
  final String username;
  final String email;

  const UserDto({
    required this.id,
    required this.username,
    required this.email
  });

}