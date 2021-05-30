using Juce.CoreUnity.UI;

namespace Playground.Content.Stage.VisualLogic.UI.DemoStages
{
    public class DemoStagesUIView : UIView
    {
        //[Header("References")]
        //[SerializeField] private PointerCallbacks demoStagesPointerCallbacks = default;

        private void Awake()
        {
            //Contract.IsNotNull(demoStagesPointerCallbacks, this);
        }

        public void Init(DemoStagesUIViewModel viewModel)
        {
            //demoStagesPointerCallbacks.OnClick += (PointerCallbacks pointerCallbacks, PointerEventData pointerEventData) =>
            //{
            //    viewModel.OnDemoStagesClicked?.Invoke(pointerCallbacks, EventArgs.Empty);
            //};
        }
    }
}
