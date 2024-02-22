using UnityEngine;

namespace AAA.Source.Platform.Runtime
{
    [CreateAssetMenu(menuName = "Temp Pal/Platform/Scriptable Objects/Platform Configuration",
        fileName = nameof(PlatformConfiguration))]
    public class PlatformConfiguration : ScriptableObject
    {
        [field: SerializeField] public byte TargetFrameRate { get; private set; }
    }
}