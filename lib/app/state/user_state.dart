import 'package:flutter/cupertino.dart';
import 'package:music_g/core/domain/domain.dart';
import 'package:shared_preferences/shared_preferences.dart';

class UserState with ChangeNotifier{
  String? _token;
  UserModel? _user;
  bool _isAuth = false;

  bool get isAuth => _isAuth;

  UserState();

  UserState._({required String token, required UserModel user, required bool isAuth}) : _token = "", _user = UserModel(id: 0, username: "", email: "", token: ""), _isAuth = false;

  String? get token => _token;
  UserModel? get user => _user;

  void checkAuth() async {
    final SharedPreferences preferences = await SharedPreferences.getInstance();
    final String? token = preferences.getString("token");
    if(token != null) _isAuth = true;
  }

  void authUser({required String token, required UserModel user}) {
    _token = token;
    _user = user;
    _isAuth = true;
    notifyListeners();
  }

  set setUser(UserModel user) {
    _user = user;
    notifyListeners();
  }

  void logOut() {
    _token = "";
    _user = null;
    _isAuth = false;
  }

}