import 'package:flutter/material.dart';
import 'package:get_it/get_it.dart';
import 'package:music_g/app/state/user_state.dart';
import 'package:music_g/core/domain/domain.dart' show AuthModel, RegisterUserUsecase;
import 'package:music_g/feature/auth/widget/auth_widget.dart';
import 'package:provider/provider.dart';
import 'package:shared_preferences/shared_preferences.dart';

class RegisterScreen extends StatefulWidget {

  final Function() navigateToLoginScreen;

  const RegisterScreen({super.key, required this.navigateToLoginScreen});

  @override
  State<RegisterScreen> createState() => _RegisterScreenState();
}

class _RegisterScreenState extends State<RegisterScreen> {

  final TextEditingController _loginController = TextEditingController();
  final TextEditingController _emailController = TextEditingController();
  final TextEditingController _passwordController = TextEditingController();
  late final RegisterUserUsecase _registerUserUsecase;

  @override
  void dispose() {
    _loginController.dispose();
    _emailController.dispose();
    _passwordController.dispose();

    super.dispose();
  }

  Future<void> _registerUser(BuildContext context) async {

    _registerUserUsecase = GetIt.instance.get<RegisterUserUsecase>();
    final SharedPreferences prefs = await SharedPreferences.getInstance();

    final res = await _registerUserUsecase.invoke(
        AuthModel(
            username: _loginController.text,
            password: _loginController.text,
            email: _emailController.text
        )
    );

    res.onSuccess((data) {
      context.read<UserState>().authUser(token: data.token, user: data);
      prefs.setString("token", data.token);
    });

    res.onError((err) {});

  }


  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        centerTitle: false,
        title: const Text("Register", style: TextStyle(
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
              LoginField( controller: _loginController,),
              const SizedBox(height: 15),
              EmailField(controller: _emailController),
              const SizedBox(height: 15),
              PasswordField(controller: _passwordController),
              const SizedBox(height: 12),

              Row(
                mainAxisAlignment: MainAxisAlignment.center,
                children: [
                  const Text(
                    "You already have an account?",
                    style: TextStyle(
                        fontSize: 15,
                        fontWeight: FontWeight.w600,
                        color: Colors.black38
                    ),
                  ),
                  TextButton(onPressed: () => widget.navigateToLoginScreen(), child: const Text(
                    "Login now!",
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
                  "Register",
                  style: TextStyle(
                      fontSize: 18,
                      fontWeight: FontWeight.w600
                  ),
                ),
                onPressed: () {
                  _registerUser(context);
                },
              ),


            ],
          ),
        ),
      ),
    );
  }
}

