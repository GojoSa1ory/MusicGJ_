import 'package:flutter/material.dart';

class EmailField extends StatelessWidget {

  final TextEditingController _controller;

  const EmailField({super.key, required TextEditingController controller}) : _controller = controller;

  @override
  Widget build(BuildContext context) {
    return TextField(
      decoration: const InputDecoration(
        border: OutlineInputBorder(borderRadius: BorderRadius.all(Radius.circular(15))),
        fillColor: Colors.white,
        filled: true,
        hintText: "example@gmail.com",
        label: Text("Email"),
        prefixIcon: Icon(Icons.email_outlined)
      ),
      maxLines: 1,
      controller: _controller,
    );
  }
}
