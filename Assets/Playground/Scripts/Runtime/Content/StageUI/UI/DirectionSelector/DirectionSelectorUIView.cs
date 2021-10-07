using Juce.CoreUnity.UI;

namespace Playground.Content.StageUI.UI.DirectionSelector
{
    public class DirectionSelectorUIView : UIView
    {
        private DirectionSelectorUIViewModel viewModel;

        private void Awake()
        {
           
        }

        public void Init(DirectionSelectorUIViewModel viewModel)
        {
            this.viewModel = viewModel;
        }
    }
}
