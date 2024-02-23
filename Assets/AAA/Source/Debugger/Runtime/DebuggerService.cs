using AAA.Source.Service.Runtime;

namespace AAA.Source.Debugger.Runtime
{
    public class DebuggerService : ApplicationService
    {
        public Debugger Debugger { get; private set; }

        public override void Initialize(ServiceController serviceController)
        {
            Debugger = new Debugger();
        }

        public override void Shutdown()
        {
        }
    }
}