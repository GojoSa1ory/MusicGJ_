import 'package:music_g/core/api/api.dart' show LoginUserRequests, RegisterUserRequest;
import 'package:music_g/core/data/auth/mapper/auth_mapper.dart';
import 'package:music_g/core/domain/domain.dart' show UserModel, AuthModel, AuthRepository;
import 'package:music_g/core/shared/shared.dart' show Result;

class AuthRepositoryImpl implements AuthRepository {
  final LoginUserRequests _loginService;
  final RegisterUserRequest _registerService;

  const AuthRepositoryImpl(this._loginService, this._registerService);

  @override
  Future<Result<UserModel, String>> loginUser(AuthModel auht) async {
    final requestDto = mapToAuthRequest(auht);
    final req = await _loginService.invoke(auth: requestDto);

    return req.isSuccess
        ? Result.success(mapToDomain(req.dataOrNull!))
        : Result.failure(req.errorOrNull!);
  }

  @override
  Future<Result<UserModel, String>> registerUser(AuthModel auht) async {

    final requestDto = mapToAuthRequest(auht);

    final req = await _registerService.invoke(auth: requestDto);

    return req.isSuccess
        ? Result.success(mapToDomain(req.dataOrNull!))
        : Result.failure(req.errorOrNull!);
  }
}
