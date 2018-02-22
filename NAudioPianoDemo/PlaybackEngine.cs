using System.Collections.Generic;
using NAudio.Wave;

namespace NAudioPianoDemo
{
    class PlaybackEngine
    {
        private readonly Dictionary<string, string> noteFiles = new Dictionary<string, string>()
        {
            {"C", "P1D V105 C4.wav"},
            {"D#", "P1D V105 Eb4.wav"},
            {"F#", "P1D V105 Gb4.wav"},
            {"A", "P1D V105 A4.wav"},
        };

        private WaveOut waveOut;

        public void StartNote(string note)
        {
            waveOut = new WaveOut();

            string file;
            if (noteFiles.TryGetValue(note, out file))
            {
                waveOut.Init(new AudioFileReader("samples\\" + file));
                waveOut.Play();
            }
        }

        public void StopNote(string noteName)
        {
            if (waveOut != null)
            {
                waveOut.Stop();
            }
        }
    }
}