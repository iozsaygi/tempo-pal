using AAA.Source.Debugger.Runtime;
using AAA.Source.Service.Runtime;
using UnityEngine;

// ReSharper disable InconsistentNaming

namespace AAA.Source.Metronome.Runtime
{
    public class MetronomeService : ApplicationService
    {
        // Required serializations.
        // TODO: See if we can use some kind of settings objects instead of direct audio clip reference.
        [SerializeField] private AudioClip audioClip;

        // Dependent service references.
        private DebuggerService debuggerService;

        // Service components.
        private MetronomeController metronomeController;

        public override void OnInitialize(ServiceController serviceController)
        {
            // Cache required service references.
            debuggerService = serviceController.GetRuntimeApplicationServiceByType<DebuggerService>();

            // Create the smaller components of this service.
            metronomeController =
                new MetronomeController(debuggerService, this, new MetronomeSettings(60, 100, audioClip));

            metronomeController.Start();
        }

        public override void OnShutdown()
        {
            metronomeController.Stop();
        }
    }
}