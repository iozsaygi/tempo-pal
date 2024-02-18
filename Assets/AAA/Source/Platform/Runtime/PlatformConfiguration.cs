using UnityEngine;

namespace AAA.Source.Platform.Runtime
{
    [CreateAssetMenu(menuName = "Tempo Pal/Scriptable Objects/Platform/Platform Configuration",
        fileName = nameof(PlatformConfiguration))]
    public class PlatformConfiguration : ScriptableObject
    {
        [field: SerializeField] public byte TargetFrameRate { get; private set; }
    }
}