import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:music_g/app/state/audio_player_state.dart';
import 'package:music_g/core/shared/shared.dart' show LoadingView, TrackCard;
import 'package:music_g/feature/track/screen/main/bloc/track_bloc.dart';

class TrackView extends StatefulWidget {
  const TrackView({super.key});

  @override
  State<TrackView> createState() => _TrackViewState();
}

class _TrackViewState extends State<TrackView> {
  late final TrackBloc _bloc;

  @override
  initState() {
    _bloc = TrackBloc();
    _bloc.add(LoadTrackEvent());
    super.initState();
  }

  @override
  void dispose() {
    _bloc.close();
    super.dispose();
  }

  @override
  Widget build(BuildContext context) {
    final playerState = context.watch<AudioPlayerState>();

    return BlocBuilder<TrackBloc, TrackState>(
        bloc: _bloc,
        builder: (context, state) {
          return state is LoadedTrack
              ? Scaffold(
                  body: Padding(
                    padding: const EdgeInsets.symmetric(horizontal: 15),
                    child: ListView.builder(
                      itemCount: state.tracks.length,
                      itemBuilder: (context, index) {
                        return TrackCard(
                            togglePlayPause: () {
                              playerState
                                  .togglePlayPause(state.tracks[index].track);
                            },
                            coverUrl: state.tracks[index].trackImage,
                            trackName: state.tracks[index].name,
                            isPlaying: playerState.isPlaying,
                            artistName: "Artist");
                      },
                    ),
                  ),
                )
              : const LoadingView();
        });
  }
}
