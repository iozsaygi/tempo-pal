using AAA.Source.Metronome.Runtime;
using AAA.Source.Service.Runtime;
using UnityEngine;

// ReSharper disable InconsistentNaming

namespace AAA.Source.UI.Runtime
{
    public class UIService : ApplicationService
    {
        // Required serializations.
        [SerializeField] private BPMView bpmView;
        [SerializeField] private BPMManipulationButton bpmIncreaseManipulationButton;
        [SerializeField] private BPMManipulationButton bpmDecreaseManipulationButton;

        // Dependent service references.
        private MetronomeService metronomeService;

        public override void OnInitialize(ServiceController serviceController)
        {
            metronomeService = serviceController.GetRuntimeApplicationServiceByType<MetronomeService>();

            bpmIncreaseManipulationButton.Inject(metronomeService.MetronomeController);
            bpmDecreaseManipulationButton.Inject(metronomeService.MetronomeController);

            bpmView.UpdateView(metronomeService.MetronomeController);
        }

        public override void OnShutdown()
        {
        }
    }
}