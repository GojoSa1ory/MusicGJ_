enum AppRoutes {

  login,
  register,
  user,
  track;

  String getRouteName() {

    switch (this) {
      case AppRoutes.login:
        return "login";
      case AppRoutes.register:
        return "register";
      case AppRoutes.user:
        return "user";
      case AppRoutes.track:
        return "track";
    }

  }
  
  String getRoute() {

    switch(this) {
      case AppRoutes.login:
        return "/login";
      case AppRoutes.register:
        return "/register";
      case AppRoutes.user:
        return "/user";
      case AppRoutes.track:
        return "/track";
    }

  }

}