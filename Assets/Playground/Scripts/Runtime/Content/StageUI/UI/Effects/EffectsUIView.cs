using Juce.CoreUnity.UI;

namespace Playground.Content.StageUI.UI.Effects
{
    public class EffectsUIView : UIView
    {

        private EffectsUIViewModel viewModel;

        private void Awake()
        {

        }

        public void Init(EffectsUIViewModel viewModel)
        {
            this.viewModel = viewModel;
        }
    }
}
