using UnityEngine;

namespace AAA.Source.Application.Runtime
{
    [CreateAssetMenu(menuName = "Tempo Pal/Scriptable Objects/Application/Application Configuration",
        fileName = nameof(ApplicationConfiguration))]
    public class ApplicationConfiguration : ScriptableObject
    {
        [field: SerializeField] public byte TargetFrameRate { get; private set; }
    }
}