using Juce.Core.DI.Container;

namespace Playground.Contexts.StageUI
{
    public interface IStageUIContext 
    {
        public IDIContainer Container { get; }
    }
}
