using AAA.Source.Debugger.Runtime;
using AAA.Source.Service.Runtime;
using UnityEngine;

// ReSharper disable InconsistentNaming

namespace AAA.Source.Metronome.Runtime
{
    public class MetronomeService : ApplicationService
    {
        // Service components.
        public MetronomeController MetronomeController { get; private set; }

        // Required serializations.
        // TODO: See if we can use some kind of settings objects instead of direct audio clip reference.
        [SerializeField] private AudioClip audioClip;
        [SerializeField] private MetronomeMainThreadDispatcher metronomeMainThreadDispatcherPrefab;

        // Dependent service references.
        private DebuggerService debuggerService;

        public override void OnInitialize(ServiceController serviceController)
        {
            // Cache required service references.
            debuggerService = serviceController.GetRuntimeApplicationServiceByType<DebuggerService>();

            // Instantiate the main thread controller prefab.
            var metronomeMainThreadController =
                Instantiate(metronomeMainThreadDispatcherPrefab, Vector3.zero, Quaternion.identity);

            metronomeMainThreadController.transform.SetParent(transform, true);

            // Create the smaller components of this service.
            MetronomeController =
                new MetronomeController(debuggerService, this, new MetronomeSettings(60, 100, audioClip),
                    metronomeMainThreadController);

            MetronomeController.Start();
        }

        public override void OnShutdown()
        {
            MetronomeController.Stop();
        }
    }
}