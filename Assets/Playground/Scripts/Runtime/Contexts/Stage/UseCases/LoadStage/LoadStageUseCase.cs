using Juce.Core.DI.Builder;
using Juce.Core.DI.Container;
using Juce.Core.Events;
using Juce.Core.Loading;
using System.Threading.Tasks;

namespace Playground.Contexts.Stage.UseCases.LoadStage
{
    public class LoadStageUseCase : ILoadStageUseCase
    {
        private readonly IDIContainer servicesContainer;
        private readonly IDIContainer stageUIContainer;

        public LoadStageUseCase(
            IDIContainer servicesContainer,
            IDIContainer stageUIContainer
            )
        {
            this.servicesContainer = servicesContainer;
            this.stageUIContainer = stageUIContainer;
        }

        public Task Execute()
        {
            TaskCompletionSource<object> stageLoadedTaskCompletionSource = new TaskCompletionSource<object>();

            ILoadingToken stageLoadedToken = new CallbackLoadingToken(
                () => stageLoadedTaskCompletionSource.SetResult(default)
                );

            EventDispatcherAndReceiver logicToViewEventDispatcherAndReceiver = new EventDispatcherAndReceiver();
            EventDispatcherAndReceiver viewToLogicEventDispatcherAndReceiver = new EventDispatcherAndReceiver();

            return stageLoadedTaskCompletionSource.Task;
        }
    }
}
