using AAA.Source.Metronome.Runtime;
using TMPro;
using UnityEngine;

// ReSharper disable InconsistentNaming

namespace AAA.Source.UI.Runtime
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class BPMView : MonoBehaviour
    {
        // Required serializations.
        [SerializeField] private TextMeshProUGUI textMeshProUGUI;

        public void UpdateView(MetronomeController metronomeController)
        {
            textMeshProUGUI.text = metronomeController.GetCurrentMetronomeSettings().BeatsPerMinute.ToString();
        }
    }
}