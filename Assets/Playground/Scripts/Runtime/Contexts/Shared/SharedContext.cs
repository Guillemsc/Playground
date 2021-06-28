using Juce.CoreUnity.Contexts;
using Juce.CoreUnity.Service;
using Playground.Content.Shared;
using Playground.Content.Shared.UseCases;
using Playground.Services;

namespace Playground.Contexts
{
    public class SharedContext : Context
    {
        public readonly static string SceneName = "SharedContext";

        public SharedUseCases SharedUseCases { get; private set; }

        protected override void Init()
        {
            PersistenceService persistanceService = ServicesProvider.GetService<PersistenceService>();

            IGetStageStarsFromTimingUseCase getStageStarsFromTimingUseCase = new GetStageStarsFromTimingUseCase();

            ITryGetStageCarStarsUseCase tryGetStageCarStarsUseCase = new TryGetStageCarStarsUseCase(
                persistanceService
                );

            ISetStageCarStarsUseCase setStageCarStarsUseCase = new SetStageCarStarsUseCase(
                persistanceService
                );

            SharedUseCases = new SharedUseCases(
                getStageStarsFromTimingUseCase,
                tryGetStageCarStarsUseCase,
                setStageCarStarsUseCase
                );

            ContextsProvider.Register(this);
        }

        protected override void CleanUp()
        {

        }
    }
}
