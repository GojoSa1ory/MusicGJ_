import 'package:flutter/material.dart';
import 'package:get_it/get_it.dart';
import 'package:music_g/app/state/user_state.dart';
import 'package:music_g/core/domain/auth/auth.dart' show LoginUsecase, AuthModel;
import 'package:provider/provider.dart';
import 'package:shared_preferences/shared_preferences.dart';
import '../../widget/auth_widget.dart' show LoginField, PasswordField;


class LoginScreen extends StatefulWidget {

  final Function() navigateToRegisterScreen;

  const LoginScreen({super.key, required this.navigateToRegisterScreen});

  @override
  State<LoginScreen> createState() => _LoginScreenState();
}

class _LoginScreenState extends State<LoginScreen> {

  final TextEditingController _loginController = TextEditingController();
  final TextEditingController _passwordController = TextEditingController();
  late final LoginUsecase _loginUsecase;

  @override
  void dispose() {
    _loginController.dispose();
    _passwordController.dispose();
    super.dispose();
  }

  Future<void> _login() async {

    _loginUsecase = GetIt.instance.get<LoginUsecase>();
    final SharedPreferences prefs = await SharedPreferences.getInstance();

    final res = await _loginUsecase.invoke(AuthModel(
      username: _loginController.text, 
      email: "",
      password: _passwordController.text)
    );

    res.onSuccess((data) {
      context.read<UserState>().authUser(token: data.token, user: data);
      prefs.setString("token", data.token);
    });

    res.onError((err) {
      showDialog(context: context, builder: (context) {
        return AlertDialog(
          title: const Text("Login failed"),
          content: Text(err),
          actions: [
            TextButton(onPressed: () {
              Navigator.pop(context);
            }, child: const Text("OK"))
          ],
        );
      },);
    });
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        centerTitle: false,
        title: const Text("Login", style: TextStyle(
          fontWeight: FontWeight.w600,
          fontSize: 28,
        )),
      ),
      body: Padding(
        padding: const EdgeInsets.symmetric(horizontal: 15),
        child: SingleChildScrollView(
          child: Column(
            mainAxisAlignment: MainAxisAlignment.start,
            crossAxisAlignment: CrossAxisAlignment.center,
            children: [
              Padding(
                padding: const EdgeInsets.only(bottom: 20),
                child: Image.asset("assets/images/logo.png", width: 280),
              ),
              LoginField(controller: _loginController,),
              const SizedBox(height: 15),
              PasswordField(controller: _passwordController),
              const SizedBox(height: 12),

              Row(
                mainAxisAlignment: MainAxisAlignment.center,
                children: [
                  const Text(
                    "You don't have an account?",
                    style: TextStyle(
                        fontSize: 15,
                        fontWeight: FontWeight.w600,
                        color: Colors.black38
                    ),
                  ),
                  TextButton(onPressed: () => widget.navigateToRegisterScreen(),
                      child: const Text(
                      "Register now!",
                      style: TextStyle(
                        fontSize: 15,
                        fontWeight: FontWeight.w700
                      ),
                  ))
                ],
              ),

              const SizedBox(height: 5),

              FilledButton.tonal(
                style: const ButtonStyle(
                    minimumSize: WidgetStatePropertyAll(Size(220, 50))
                ),
                child: const Text(
                  "Login",
                  style: TextStyle(
                      fontSize: 18,
                      fontWeight: FontWeight.w600
                  ),
                ),
                onPressed: () {
                  _login();
                },
              ),
            ],
          ),
        ),
      ),
    );
  }
}

