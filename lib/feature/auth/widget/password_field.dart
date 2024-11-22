import 'package:flutter/material.dart';

class PasswordField extends StatelessWidget {

  final TextEditingController _controller;

  const PasswordField({super.key, required TextEditingController controller}): _controller = controller;

  @override
  Widget build(BuildContext context) {
    return TextField(
      decoration: const InputDecoration(
          border: OutlineInputBorder(borderRadius: BorderRadius.all(Radius.circular(15))),
          fillColor: Colors.white,
          filled: true,
          hintText: "********",
          label: Text("Password"),
          prefixIcon: Icon(Icons.password_outlined),
      ),
      obscureText: true,
      maxLines: 1,
      controller: _controller,
    );
  }
}