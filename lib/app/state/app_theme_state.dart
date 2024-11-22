import 'package:flutter/cupertino.dart';

class AppThemeState with ChangeNotifier{
  bool _isDarkMode = false;

  get isDarkMode => _isDarkMode;
  void changeTheme() => !_isDarkMode;
}