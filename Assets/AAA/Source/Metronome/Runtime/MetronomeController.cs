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
        private readonly MetronomeMainThreadDispatcher metronomeMainThreadDispatcher;

        // Required references for audio bridge.
        private GameObject gameObject;
        private AudioSource audioSource;

        // Thread management.
        private Thread thread;
        private bool isThreadRunning;

        public MetronomeController(DebuggerService debuggerService, MetronomeService metronomeService,
            MetronomeSettings metronomeSettings, MetronomeMainThreadDispatcher metronomeMainThreadDispatcher)
        {
            this.debuggerService = debuggerService;
            this.metronomeService = metronomeService;
            this.metronomeSettings = metronomeSettings;
            this.metronomeMainThreadDispatcher = metronomeMainThreadDispatcher;
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
            audioSource.volume = metronomeSettings.Volume;

            gameObject.transform.SetParent(metronomeService.transform, true);

            debuggerService.Debugger.Log("Instantiated new audio bridge", nameof(MetronomeController));
        }

        private void SetupThread()
        {
            thread = new Thread(Click);
            isThreadRunning = true;
            thread.Start();
        }

        private void Click()
        {
            const float accuracyReference = 60000.0f;
            var sleepDurationInMilliseconds = (int)(accuracyReference / metronomeSettings.BeatsPerMinute);

            while (isThreadRunning)
            {
                // TODO: See if we need better way to manage thread than just a 'Sleep' function.
                Thread.Sleep(sleepDurationInMilliseconds);

                metronomeMainThreadDispatcher.QueueClickOnMainThread(() => { audioSource.Play(); });
            }
        }
    }
}