using Juce.CoreUnity.Contexts;
using Playground.Content.Shared;
using Playground.Content.Shared.UseCases;

namespace Playground.Contexts
{
    public class SharedContext : Context
    {
        public readonly static string SceneName = "SharedContext";

        public SharedUseCases SharedUseCases { get; private set; }

        protected override void Init()
        {
            IGetStageStarsFromTimingUseCase getStageStarsFromTimingUseCase = new GetStageStarsFromTimingUseCase();

            SharedUseCases = new SharedUseCases(
                getStageStarsFromTimingUseCase
                );

            ContextsProvider.Register(this);
        }

        protected override void CleanUp()
        {

        }
    }
}
