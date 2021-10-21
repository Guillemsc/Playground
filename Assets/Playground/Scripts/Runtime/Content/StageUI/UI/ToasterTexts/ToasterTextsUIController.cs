using Juce.Core.Subscribables;

namespace Playground.Content.StageUI.UI.ToasterTexts
{
    public class ToasterTextsUIController : ISubscribable
    {
        private readonly ToasterTextsUIViewModel viewModel;

        public ToasterTextsUIController(
            ToasterTextsUIViewModel viewModel
            )
        {
            this.viewModel = viewModel;
        }

        public void Subscribe()
        {

        }

        public void Unsubscribe()
        {

        }
    }
}
