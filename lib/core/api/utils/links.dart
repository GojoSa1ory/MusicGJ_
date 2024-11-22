enum RequestsLinks {

  baseLink,
  registerLink,
  loginLink,
  getTracks;

  String getLink() {

    switch (this) {
      case RequestsLinks.baseLink:
        return "http://10.0.2.2:5214/api";
      case RequestsLinks.registerLink:
        return "http://10.0.2.2:5214/api/auth/register";
      case RequestsLinks.loginLink:
        return "http://10.0.2.2:5214/api/auth/login";
      case RequestsLinks.getTracks:
        return "${RequestsLinks.baseLink.getLink()}/tracks/all";
    }

  }
  
}