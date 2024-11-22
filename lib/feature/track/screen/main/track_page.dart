import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:music_g/feature/track/screen/main/bloc/track_bloc.dart';
import 'package:music_g/feature/track/screen/main/track_view.dart';

class TrackPage extends StatelessWidget {
  const TrackPage({super.key});

  @override
  Widget build(BuildContext context) {
    return BlocProvider(
      create: (_) => TrackBloc(),
      child: TrackView(),
    );
  }
}

