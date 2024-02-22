using AAA.Source.Service.Runtime;
using UnityEngine;

namespace AAA.Source.Platform.Runtime
{
    public class PlatformService : ApplicationService
    {
        [SerializeField] private PlatformConfiguration platformConfiguration;

        public override void Initialize()
        {
            QualitySettings.vSyncCount = 0;
            Application.targetFrameRate = platformConfiguration.TargetFrameRate;
        }

        public override void Shutdown()
        {
        }
    }
}