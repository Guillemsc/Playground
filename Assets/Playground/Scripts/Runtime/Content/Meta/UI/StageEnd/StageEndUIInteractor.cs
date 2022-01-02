using Juce.Core.Subscribables;
using Playground.Content.Meta.UI.StageEnd.UseCases.Init;

namespace Playground.Content.Meta.UI.StageEnd
{
    public class StageEndUIInteractor : IStageEndUIInteractor, ISubscribable
    {
        private readonly StageEndUIViewModel viewModel;
        private readonly IInitUseCase initUseCase;

        public StageEndUIInteractor(
            StageEndUIViewModel viewModel,
            IInitUseCase initUseCase
            )
        {
            this.viewModel = viewModel;
            this.initUseCase = initUseCase;
        }

        public void Subscribe()
        {

        }

        public void Unsubscribe()
        {

        }

        public void Refresh()
        {

        }

        public void Init(int currentPoints)
        {
            initUseCase.Execute(currentPoints);
        }
    }
}
