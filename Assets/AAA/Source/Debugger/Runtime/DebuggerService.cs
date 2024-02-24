using AAA.Source.Service.Runtime;

namespace AAA.Source.Debugger.Runtime
{
    public class DebuggerService : ApplicationService
    {
        public Debugger Debugger { get; private set; }

        public override void OnInitialize(ServiceController serviceController)
        {
            Debugger = new Debugger();
        }

        public override void OnShutdown()
        {
        }
    }
}