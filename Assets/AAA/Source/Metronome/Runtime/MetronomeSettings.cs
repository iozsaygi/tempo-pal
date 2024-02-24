using UnityEngine;

namespace AAA.Source.Metronome.Runtime
{
    public readonly struct MetronomeSettings
    {
        public readonly byte BeatsPerMinute;
        public readonly AudioClip AudioClip;

        public MetronomeSettings(byte beatsPerMinute, AudioClip audioClip)
        {
            BeatsPerMinute = beatsPerMinute;
            AudioClip = audioClip;
        }
    }
}