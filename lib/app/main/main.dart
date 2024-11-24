import 'package:flutter/material.dart';
import 'package:get_it/get_it.dart';
import 'package:music_g/app/navigation/router.dart';
import 'package:music_g/app/state/audio_player_state.dart';
import 'package:music_g/app/state/app_theme_state.dart';
import 'package:music_g/app/state/user_state.dart';
import 'package:music_g/core/api/api.dart' show setupApiDi;
import 'package:music_g/core/data/data.dart' show setupDataDi;
import 'package:music_g/core/domain/domain.dart';

import 'package:provider/provider.dart';

void setupDomain() {

  final authRep = GetIt.instance.get<AuthRepository>();

  GetIt.instance.registerFactory<LoginUsecase>(() {
    return LoginUsecase(authRep);
  });

  GetIt.instance.registerFactory<RegisterUserUsecase>(() {
    return RegisterUserUsecase(authRep);
  });

}

void setupDi() {
  setupDataDi();
  setupApiDi();
  setupDomain();
}

void main() {
  setupDi();
  runApp(
    MultiProvider(
      providers: [
        ChangeNotifierProvider(create: (_) => UserState()),
        ChangeNotifierProvider(create: (_) => AppThemeState()),
        ChangeNotifierProvider(create: (_) => AudioPlayerState())
      ],
      child: const MyApp(),
    )
  );
}

class MyApp extends StatelessWidget {

  const MyApp({super.key});



  @override
  Widget build(BuildContext context) {

    context.read<UserState>().checkAuth();

    return MaterialApp.router(
      title: "MusicG",
      theme: ThemeData(
        colorScheme: ColorScheme.fromSeed(seedColor: Colors.deepPurpleAccent),
        useMaterial3: true
      ),
      routerConfig: AppRouter.router(context.watch<UserState>().isAuth),
    );
  }
}

