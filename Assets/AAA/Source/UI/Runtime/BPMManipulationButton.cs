using AAA.Source.Metronome.Runtime;
using UnityEngine;
using UnityEngine.UI;

// ReSharper disable InconsistentNaming

namespace AAA.Source.UI.Runtime
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(Button))]
    public class BPMManipulationButton : MonoBehaviour
    {
        // Required serializations.
        [SerializeField] private BPMView bpmView;

        // Dependent service components.
        private MetronomeController metronomeController;

        public void Inject(MetronomeController metronomeControllerReference)
        {
            metronomeController = metronomeControllerReference;
        }

        public void Manipulate(int rate)
        {
            metronomeController.Stop();

            var currentMetronomeSettings = metronomeController.GetCurrentMetronomeSettings();
            metronomeController.UpdateMetronomeSettings(new MetronomeSettings(
                (byte)(currentMetronomeSettings.BeatsPerMinute + rate),
                currentMetronomeSettings.Volume, currentMetronomeSettings.AudioClip));

            metronomeController.Start();

            bpmView.UpdateView(metronomeController);
        }
    }
}