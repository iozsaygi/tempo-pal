using System.Threading;
using AAA.Source.Debugger.Runtime;
using UnityEngine;

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

        // Thread management.
        private Thread thread;
        private bool isThreadRunning;

        public MetronomeController(DebuggerService debuggerService, MetronomeService metronomeService,
            MetronomeSettings metronomeSettings)
        {
            this.debuggerService = debuggerService;
            this.metronomeService = metronomeService;
            this.metronomeSettings = metronomeSettings;
        }

        public void Start()
        {
            InstantiateAudioBridge();
            SetupThread();
        }

        // TODO: Check if it makes sense to use 'IDisposable' for this purpose.
        public void Stop()
        {
            thread.Abort();
            isThreadRunning = false;
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

            debuggerService.Debugger.Log("Instantiated new audio bridge", nameof(InstantiateAudioBridge));
        }

        private void SetupThread()
        {
            thread = new Thread(Click);
            isThreadRunning = true;
            thread.Start();
        }

        private void Click()
        {
            while (isThreadRunning)
            {
                Thread.Sleep(1000);
                Debug.Log("This is test message");
            }
        }
    }
}