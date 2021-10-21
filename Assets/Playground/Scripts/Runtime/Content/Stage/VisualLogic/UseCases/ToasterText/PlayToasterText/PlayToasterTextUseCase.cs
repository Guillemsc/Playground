using Playground.Content.StageUI.UI.ToasterTexts;

namespace Playground.Content.Stage.VisualLogic.UseCases.PlayToasterText
{
    public class PlayToasterTextUseCase : IPlayToasterTextUseCase
    {
        private readonly IToasterTextsUIInteractor toasterTextsUIInteractor;

        public PlayToasterTextUseCase(
            IToasterTextsUIInteractor toasterTextsUIInteractor
            )
        {
            this.toasterTextsUIInteractor = toasterTextsUIInteractor;
        }

        public void Execute(string text)
        {
            toasterTextsUIInteractor.PlayToasterText(text);
        }
    }
}
