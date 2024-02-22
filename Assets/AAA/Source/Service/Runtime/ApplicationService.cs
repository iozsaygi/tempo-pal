using UnityEngine;

namespace AAA.Source.Service.Runtime
{
    [DisallowMultipleComponent]
    public abstract class ApplicationService : MonoBehaviour
    {
        public abstract void Initialize(ServiceController serviceController);
        public abstract void Shutdown();
    }
}