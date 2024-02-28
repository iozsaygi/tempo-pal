using AAA.Source.Debugger.Runtime;
using AAA.Source.Service.Runtime;
using UnityEngine;
using UnityEngine.Serialization;

// ReSharper disable InconsistentNaming

namespace AAA.Source.Metronome.Runtime
{
    public class MetronomeService : ApplicationService
    {
        // Required serializations.
        // TODO: See if we can use some kind of settings objects instead of direct audio clip reference.
        [SerializeField] private AudioClip audioClip;
        [FormerlySerializedAs("metronomeMainThreadControllerPrefab")] [SerializeField] private MetronomeMainThreadDispatcher metronomeMainThreadDispatcherPrefab;

        // Dependent service references.
        private DebuggerService debuggerService;

        // Service components.
        private MetronomeController metronomeController;

        public override void OnInitialize(ServiceController serviceController)
        {
            // Cache required service references.
            debuggerService = serviceController.GetRuntimeApplicationServiceByType<DebuggerService>();

            // Instantiate the main thread controller prefab.
            var metronomeMainThreadController =
                Instantiate(metronomeMainThreadDispatcherPrefab, Vector3.zero, Quaternion.identity);

            metronomeMainThreadController.transform.SetParent(transform, true);

            // Create the smaller components of this service.
            metronomeController =
                new MetronomeController(debuggerService, this, new MetronomeSettings(60, 100, audioClip),
                    metronomeMainThreadController);

            metronomeController.Start();
        }

        public override void OnShutdown()
        {
            metronomeController.Stop();
        }
    }
}