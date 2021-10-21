using Juce.Core.Subscribables;
using Playground.Content.StageUI.UI.ToasterTexts.UseCases.PlayToasterText;
using System.Threading;

namespace Playground.Content.StageUI.UI.ToasterTexts
{
    public class ToasterTextsUIInteractor : IToasterTextsUIInteractor, ISubscribable
    {
        private readonly ToasterTextsUIViewModel viewModel;
        private readonly IPlayToasterTextUseCase playToasterTextUseCase;

        public ToasterTextsUIInteractor(
            ToasterTextsUIViewModel viewModel,
            IPlayToasterTextUseCase playToasterTextUseCase
            )
        {
            this.viewModel = viewModel;
            this.playToasterTextUseCase = playToasterTextUseCase;
        }

        public void Subscribe()
        {
          
        }

        public void Unsubscribe()
        {

        }

        public void PlayToasterText(string text)
        {
            playToasterTextUseCase.Execute(text, CancellationToken.None).RunAsync();
        }
    }
}
