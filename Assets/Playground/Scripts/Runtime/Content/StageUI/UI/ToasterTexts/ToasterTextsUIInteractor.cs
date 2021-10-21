using Juce.Core.Subscribables;

namespace Playground.Content.StageUI.UI.ToasterTexts
{
    public class ToasterTextsUIInteractor : IToasterTextsUIInteractor, ISubscribable
    {
        private readonly ToasterTextsUIViewModel viewModel;

        public ToasterTextsUIInteractor(
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
