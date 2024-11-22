import 'package:music_g/core/domain/auth/model/auth_model.dart';
import 'package:music_g/core/domain/user/model/user_model.dart';
import 'package:music_g/core/shared/result.dart';

import '../repository/auth_repository.dart';

class RegisterUserUsecase {
  final AuthRepository _rep;

  const RegisterUserUsecase(this._rep);

  Future<Result<UserModel, String>> invoke(AuthModel auth) {
    return _rep.registerUser(auth);
  }
  
}