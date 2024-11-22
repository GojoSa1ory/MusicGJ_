class AuthModel {
  final String username;
  final String email;
  final String password;

  const AuthModel({
    required this.username,
    this.email = "",
    required this.password,
  });
}