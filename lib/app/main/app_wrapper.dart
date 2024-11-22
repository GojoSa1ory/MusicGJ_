import 'package:flutter/material.dart';
import 'package:go_router/go_router.dart';

class AppWrapper extends StatefulWidget {
  final StatefulNavigationShell navigationShell;

  const AppWrapper({super.key, required this.navigationShell});

  @override
  State<AppWrapper> createState() => _AppWrapperState();
}

class _AppWrapperState extends State<AppWrapper> {
  int _currentIndex = 0;

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: widget.navigationShell,
      bottomNavigationBar: BottomNavigationBar(
          onTap: (index) => setState(() {
                _currentIndex = index;
              }),
          currentIndex: _currentIndex,
          items: const [
            BottomNavigationBarItem(
                icon: Icon(Icons.home_filled),
                label: "Home"
            ),
            BottomNavigationBarItem(
                icon: Icon(Icons.settings),
                label: "Settings"
            ),
          ]),
    );
  }
}
