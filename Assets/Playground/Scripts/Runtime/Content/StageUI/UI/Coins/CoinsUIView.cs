using Juce.CoreUnity.UI;

namespace Playground.Content.StageUI.UI.Coins
{
    public class CoinsUIView : UIView
    {
        private CoinsUIViewModel viewModel;

        private void Awake()
        {

        }

        public void Init(CoinsUIViewModel viewModel)
        {
            this.viewModel = viewModel;
        }
    }
}
