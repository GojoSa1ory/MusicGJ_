import 'package:flutter/material.dart';

class TrackCard extends StatelessWidget {
  final Function() togglePlayPause;
  final String coverUrl;
  final String trackName;
  final String artistName;
  final bool isPlaying;

  const TrackCard(
      {super.key,
      required this.togglePlayPause,
      required this.coverUrl,
      required this.trackName,
      required this.isPlaying,
      required this.artistName});

  @override
  Widget build(BuildContext context) {
    return Card(
      shape: RoundedRectangleBorder(
        borderRadius: BorderRadius.circular(15),
      ),
      elevation: 5,
      margin: const EdgeInsets.symmetric(vertical: 10, horizontal: 20),
      child: Padding(
        padding: const EdgeInsets.all(15.0),
        child: Row(
          children: [
            ClipRRect(
              borderRadius: BorderRadius.circular(10),
              child: Image.network(
                coverUrl,
                width: 80,
                height: 80,
                fit: BoxFit.cover,
              ),
            ),
            const SizedBox(width: 15),
            Expanded(
              child: Column(
                crossAxisAlignment: CrossAxisAlignment.start,
                children: [
                  Text(
                    trackName,
                    style: const TextStyle(
                      fontSize: 18,
                      fontWeight: FontWeight.bold,
                    ),
                  ),
                  const SizedBox(height: 5),
                  Text(
                    artistName,
                    style: const TextStyle(
                      fontSize: 16,
                      color: Colors.grey,
                    ),
                  ),
                ],
              ),
            ),
            IconButton(
              icon: Icon(
                isPlaying ? Icons.pause_circle_filled : Icons.play_circle_fill,
                size: 40,
                color: Colors.blue,
              ),
              onPressed: togglePlayPause,
            ),
          ],
        ),
      ),
    );
  }
}
