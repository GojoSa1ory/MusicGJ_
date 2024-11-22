import 'package:flutter/material.dart';

class LoginField extends StatelessWidget {


  final TextEditingController _controller;

  const LoginField({
    super.key,
    required TextEditingController controller
  }): _controller = controller;

  @override
  Widget build(BuildContext context) {
    return TextField(
      decoration: const InputDecoration(
          border: OutlineInputBorder(borderRadius: BorderRadius.all(Radius.circular(15))),
          fillColor: Colors.white,
          filled: true,
          hintText: "Login",
          label: Text("Login"),
          prefixIcon: Icon(Icons.person_2_outlined)
      ),
      maxLines: 1,
      controller: _controller,
    );
  }
}
