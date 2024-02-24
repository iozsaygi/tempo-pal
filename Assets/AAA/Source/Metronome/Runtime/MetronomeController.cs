using AAA.Source.Debugger.Runtime;

// ReSharper disable InconsistentNaming

namespace AAA.Source.Metronome.Runtime
{
    public class MetronomeController
    {
        private readonly DebuggerService debuggerService;

        private readonly MetronomeSettings metronomeSettings;

        public MetronomeController(DebuggerService debuggerService, MetronomeSettings metronomeSettings)
        {
            this.debuggerService = debuggerService;
            this.metronomeSettings = metronomeSettings;
        }
    }
}