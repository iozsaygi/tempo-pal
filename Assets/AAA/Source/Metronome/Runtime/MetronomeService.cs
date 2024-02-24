using AAA.Source.Debugger.Runtime;
using AAA.Source.Service.Runtime;

// ReSharper disable InconsistentNaming

namespace AAA.Source.Metronome.Runtime
{
    public class MetronomeService : ApplicationService
    {
        // Dependent service references.
        private DebuggerService debuggerService;

        // Service components.
        private MetronomeController metronomeController;

        public override void OnInitialize(ServiceController serviceController)
        {
            // Cache required service references.
            debuggerService = serviceController.GetRuntimeApplicationServiceByType<DebuggerService>();

            // Create the smaller components of this service.
            metronomeController = new MetronomeController(debuggerService, new MetronomeSettings(60, null));
        }

        public override void OnShutdown()
        {
        }
    }
}