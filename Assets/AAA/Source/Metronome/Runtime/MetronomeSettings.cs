using UnityEngine;

namespace AAA.Source.Metronome.Runtime
{
    public readonly struct MetronomeSettings
    {
        public readonly byte BeatsPerMinute;
        public readonly byte Volume;

        public readonly AudioClip AudioClip;

        public MetronomeSettings(byte beatsPerMinute, byte volume, AudioClip audioClip)
        {
            BeatsPerMinute = beatsPerMinute;
            Volume = volume;
            AudioClip = audioClip;
        }
    }
}