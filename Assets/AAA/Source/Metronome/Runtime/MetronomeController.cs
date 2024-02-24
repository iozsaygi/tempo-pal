using AAA.Source.Debugger.Runtime;
using UnityEngine;
using Object = UnityEngine.Object;

// ReSharper disable InconsistentNaming

namespace AAA.Source.Metronome.Runtime
{
    public class MetronomeController
    {
        // Dependencies.
        private readonly DebuggerService debuggerService;
        private readonly MetronomeService metronomeService;
        private readonly MetronomeSettings metronomeSettings;

        // Required references for audio bridge.
        private GameObject gameObject;
        private AudioSource audioSource;

        public MetronomeController(DebuggerService debuggerService, MetronomeService metronomeService,
            MetronomeSettings metronomeSettings)
        {
            this.debuggerService = debuggerService;
            this.metronomeService = metronomeService;
            this.metronomeSettings = metronomeSettings;

            InstantiateAudioBridge();
        }

        private void InstantiateAudioBridge()
        {
            // Create required objects.
            gameObject = new GameObject(nameof(MetronomeController));
            audioSource = gameObject.AddComponent<AudioSource>();

            // Update audio source settings.
            audioSource.playOnAwake = false;
            audioSource.loop = false;
            audioSource.clip = metronomeSettings.AudioClip;

            gameObject.transform.SetParent(metronomeService.transform, true);
        }
    }
}