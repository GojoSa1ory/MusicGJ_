import 'package:flutter/cupertino.dart';
import 'package:go_router/go_router.dart';
import 'package:music_g/app/main/app_wrapper.dart';
import 'package:music_g/app/navigation/routes.dart';
import 'package:music_g/feature/feature.dart';

class AppRouter {
  AppRouter._();

  static final _rootNavigatorKey =
      GlobalKey<NavigatorState>(debugLabel: "root");
  static final _trackNavigatorKey =
      GlobalKey<NavigatorState>(debugLabel: "track");
  static final _userNavigatorKey =
      GlobalKey<NavigatorState>(debugLabel: "user");

  static GoRouter router(bool isAuth) {

    return GoRouter(

        navigatorKey: _rootNavigatorKey,
        initialLocation: isAuth
            ? AppRoutes.track.getRoute()
            : AppRoutes.login.getRoute(),
        routes: [

          GoRoute(
              path: AppRoutes.register.getRoute(),
              name: AppRoutes.register.getRouteName(),
              builder: (context, state) => RegisterScreen(
                navigateToLoginScreen: () => context.goNamed(AppRoutes.login.getRouteName()),
              ),
          ),

          GoRoute(
              path: AppRoutes.login.getRoute(),
              name: AppRoutes.login.getRouteName(),
              builder: (context, state) => LoginScreen(navigateToRegisterScreen: () => context.goNamed(AppRoutes.register.getRouteName())),
          ),

          StatefulShellRoute.indexedStack(
              builder: (context, state, navigationShell) => AppWrapper(navigationShell: navigationShell),
              branches: [

                StatefulShellBranch(
                  navigatorKey: _trackNavigatorKey,
                  routes: [
                    GoRoute(
                      path: AppRoutes.track.getRoute(),
                      name: AppRoutes.track.getRouteName(),
                      builder: (context, state) => const TrackPage(),
                    )
                  ]
                ),

                StatefulShellBranch(
                    navigatorKey: _userNavigatorKey,
                    routes: [
                      GoRoute(
                        path: AppRoutes.user.getRoute(),
                        name: AppRoutes.user.getRouteName(),
                        builder: (context, state) => const Text("Hello"),
                      )
                    ]
                ),

                

              ]
          )
        ]);
  }

}
