import 'package:music_g/core/domain/user/user.dart';
import 'package:music_g/core/shared/shared.dart' show Result;
import '../model/auth_model.dart';

abstract class AuthRepository {
  Future<Result<UserModel, String>> registerUser(AuthModel auht);
  Future<Result<UserModel, String>> loginUser(AuthModel auht);
}

