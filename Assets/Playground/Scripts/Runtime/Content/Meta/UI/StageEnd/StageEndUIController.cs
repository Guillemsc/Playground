using Juce.Core.Subscribables;
using Playground.Content.Meta.UI.StageEnd.UseCases.PlayAgain;
using UnityEngine.EventSystems;

namespace Playground.Content.Meta.UI.StageEnd
{
    public class StageEndUIController : ISubscribable
    {
        private readonly StageEndUIViewModel viewModel;
        private readonly IPlayAgainUseCase playAgainUseCase;

        public StageEndUIController(
            StageEndUIViewModel viewModel,
            IPlayAgainUseCase playAgainUseCase
            )
        {
            this.viewModel = viewModel;
            this.playAgainUseCase = playAgainUseCase;
        }

        public void Subscribe()
        {
            viewModel.OnPlayAgainEvent.OnExecute += OnPlayAgainEvent;
        }

        public void Unsubscribe()
        {
            viewModel.OnPlayAgainEvent.OnExecute -= OnPlayAgainEvent;
        }

        private void OnPlayAgainEvent(StageEndUIView stageEndUIView, PointerEventData pointerEventData)
        {
            playAgainUseCase.Execute();
        }
    }
}
