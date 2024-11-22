import 'package:music_g/core/domain/auth/repository/auth_repository.dart';
import 'package:music_g/core/shared/shared.dart';

import '../../user/model/user_model.dart';
import '../model/auth_model.dart';

class LoginUsecase {

  final AuthRepository _rep;

  const LoginUsecase(this._rep);

  Future<Result<UserModel, String>> invoke(AuthModel auth) {
    return _rep.loginUser(auth);
  }
  
}
