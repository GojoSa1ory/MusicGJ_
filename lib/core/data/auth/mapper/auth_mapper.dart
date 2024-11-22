import 'package:music_g/core/api/api.dart';
import 'package:music_g/core/domain/domain.dart';

UserModel mapToDomain(ResponseAuthDto auth) => UserModel(id: auth.user.id, username: auth.user.username, email: auth.user.email, token: auth.token);

RequestAuthDto mapToAuthRequest(AuthModel auth) => RequestAuthDto(username: auth.username, email: auth.email, password: auth.password);