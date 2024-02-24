using AAA.Source.Debugger.Runtime;

// ReSharper disable InconsistentNaming

namespace AAA.Source.Metronome.Runtime
{
    public class MetronomeController
    {
        private readonly DebuggerService debuggerService;

        public MetronomeController(DebuggerService debuggerService)
        {
            this.debuggerService = debuggerService;
        }
    }
}