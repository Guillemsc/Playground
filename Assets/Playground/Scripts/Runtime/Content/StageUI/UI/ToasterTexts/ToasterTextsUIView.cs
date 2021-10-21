using Juce.CoreUnity.UI;

namespace Playground.Content.StageUI.UI.ToasterTexts
{
    public class ToasterTextsUIView : UIView
    {
        private ToasterTextsUIViewModel viewModel;

        private void Awake()
        {

        }

        public void Init(ToasterTextsUIViewModel viewModel)
        {
            this.viewModel = viewModel;
        }
    }
}
