using Juce.Core.DI.Builder;
using Juce.Core.Disposables;
using Juce.Core.Factories;
using Juce.Core.Repositories;
using Juce.CoreUnity.Tickables;
using Playground.Content.Stage.VisualLogic.Entities;
using Playground.Content.Stage.VisualLogic.Setup;
using Playground.Content.Stage.VisualLogic.State;
using Playground.Content.Stage.VisualLogic.Tickables;
using Playground.Content.Stage.VisualLogic.UseCases.CleanPointGoals;
using Playground.Content.Stage.VisualLogic.UseCases.DespawnPointGoal;
using Playground.Content.Stage.VisualLogic.UseCases.GeneratePointGoals;
using Playground.Content.Stage.VisualLogic.UseCases.SetPointGoalAsCollected;
using Playground.Content.Stage.VisualLogic.UseCases.SetPointGoalsTickablesActive;
using Playground.Content.Stage.VisualLogic.UseCases.TrySpawnPointGoal;
using Playground.Contexts.Stage;

namespace Playground.Content.Stage.VisualLogic.Installers
{
    public static class PointGoalsInstaller
    {
        public static void InstallPointGoals(
            this IDIContainerBuilder container,
            TickablesService tickablesService,
            StageVisualLogicSetup visualLogicStageSetup,
            StageContextInstance stageContextReferences
            )
        {
            container.Bind<IFactory<PointGoalEntityViewDefinition, IDisposable<PointGoalEntityView>>>()
                .FromFunction(c => new PointGoalEntityViewFactory(
                    visualLogicStageSetup.PointGoalsSetup.Prefab,
                    stageContextReferences.PointGoalsParent
                    ));

            container.Bind<IRepository<IDisposable<PointGoalEntityView>>, SimpleRepository<IDisposable<PointGoalEntityView>>>()
                .FromNew();

            container.Bind<ITrySpawnPointGoalUseCase>()
                .FromFunction(c => new TrySpawnPointGoalUseCase(
                    c.Resolve<IFactory<PointGoalEntityViewDefinition, IDisposable<PointGoalEntityView>>>(),
                    c.Resolve<IRepository<IDisposable<PointGoalEntityView>>>(),
                    c.Resolve<PointsState>()
                    ));

            container.Bind<IDespawnPointGoalUseCase>()
                .FromFunction(c => new DespawnPointGoalUseCase(
                    c.Resolve<IRepository<IDisposable<PointGoalEntityView>>>()
                    ));

            container.Bind<IGeneratePointGoalsUseCase>()
                .FromFunction(c => new GeneratePointGoalsUseCase(
                    c.Resolve<ISingleRepository<IDisposable<ShipEntityView>>>(),
                    c.Resolve<IRepository<IDisposable<PointGoalEntityView>>>(),
                    stageContextReferences.SectionsStartPosition,
                    visualLogicStageSetup.PointGoalsSetup,
                    stageContextReferences.StageSettings,
                    c.Resolve<ITrySpawnPointGoalUseCase>()
                    ));

            container.Bind<ICleanPointGoalsUseCase>()
                .FromFunction(c => new CleanPointGoalsUseCase(
                    c.Resolve<ISingleRepository<IDisposable<ShipEntityView>>>(),
                    c.Resolve<IRepository<IDisposable<PointGoalEntityView>>>(),
                    stageContextReferences.StageSettings,
                    c.Resolve<IDespawnPointGoalUseCase>()
                    ));

            container.Bind<GeneratePointGoalsTickable>()
               .FromFunction((c) => new GeneratePointGoalsTickable(
                   c.Resolve<IGeneratePointGoalsUseCase>()
                   ))
               .WhenInit((c, o) => tickablesService.AddTickable(o))
               .WhenDispose((o) => tickablesService.RemoveTickable(o));

            container.Bind<CleanPointGoalsTickable>()
                 .FromFunction((c) => new CleanPointGoalsTickable(
                   c.Resolve<ICleanPointGoalsUseCase>()
                   ))
               .WhenInit((c, o) => tickablesService.AddTickable(o))
               .WhenDispose((o) => tickablesService.RemoveTickable(o));

            container.Bind<ISetPointGoalsTickablesActiveUseCase>()
                .FromFunction(c => new SetPointGoalsTickablesActiveUseCase(
                    c.Resolve<GeneratePointGoalsTickable>(),
                    c.Resolve<CleanPointGoalsTickable>()
                    ));

            container.Bind<ISetPointGoalAsCollectedUseCase>()
                .FromFunction(c => new SetPointGoalAsCollectedUseCase(
                     c.Resolve<IRepository<IDisposable<PointGoalEntityView>>>()
                    ));
        }
    }
}
