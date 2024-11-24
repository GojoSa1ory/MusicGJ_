import 'package:audioplayers/audioplayers.dart';
import 'package:flutter/cupertino.dart';

class AudioPlayerState with ChangeNotifier {

  final AudioPlayer _audioPlayer = AudioPlayer();
  bool _isPlaying = false;
  Duration _currentPosition = Duration.zero;
  Duration _totalDuration = Duration.zero;

  bool get isPlaying => _isPlaying;

  Duration get currentPosition => _currentPosition;

  Duration get totalDuration => _totalDuration;

  AudioPlayerState() {
    _audioPlayer.onDurationChanged.listen((Duration duration) {
      _totalDuration = duration;
      notifyListeners();
    });
    _audioPlayer.onPositionChanged.listen((Duration position) {
      _currentPosition = position;
      notifyListeners();
    });
  }

  Future<void> play(String url) async {
    await _audioPlayer.play(UrlSource(url));
    _isPlaying = true;
    notifyListeners();
  }

  Future<void> pause() async {
    await _audioPlayer.pause();
    _isPlaying = false;
    notifyListeners();
  }

  void togglePlayPause(String url) {
    if (_isPlaying) {
      pause();
    } else {
      play(url);
    }
  }
}
