using Juce.Core.DI.Builder;
using Juce.Core.Disposables;
using Juce.Core.Factories;
using Juce.Core.Repositories;
using Juce.CoreUnity.Services;
using Playground.Content.Stage.VisualLogic.Entities;
using Playground.Content.Stage.VisualLogic.Setup;
using Playground.Content.Stage.VisualLogic.Tickables;
using Playground.Content.Stage.VisualLogic.UseCases.CleanSections;
using Playground.Content.Stage.VisualLogic.UseCases.DespawnSection;
using Playground.Content.Stage.VisualLogic.UseCases.GenerateSections;
using Playground.Content.Stage.VisualLogic.UseCases.SetSectionsTickablesActive;
using Playground.Content.Stage.VisualLogic.UseCases.TrySpawnRandomSection;
using Playground.Content.Stage.VisualLogic.UseCases.TrySpawnRandomSectionEffect;
using Playground.Content.Stage.VisualLogic.UseCases.TrySpawnRandomSectionElement;
using Playground.Content.Stage.VisualLogic.UseCases.TrySpawnSectionCoin;
using Playground.Contexts.Stage;

namespace Playground.Content.Stage.VisualLogic.Installers
{
    public static class SectionsInstaller
    {
        public static void InstallSections(
            this IDIContainerBuilder container,
            TickablesService tickablesService,
            StageVisualLogicSetup visualLogicStageSetup,
            StageContextReferences stageContextReferences
            )
        {
            container.Bind<IFactory<SectionEntityViewDefinition, IDisposable<SectionEntityView>>>()
                .FromFunction((c) => new SectionEntityViewFactory(
                    parent: stageContextReferences.SectionsParent
                    ));

            container.Bind<IRepository<IDisposable<SectionEntityView>>, SimpleRepository<IDisposable<SectionEntityView>>>()
                .FromNew();

            container.Bind<ITrySpawnRandomSectionEffectUseCase>()
                .FromFunction((c) => new TrySpawnRandomSectionEffectUseCase(
                    c.Resolve<IFactory<EffectEntityViewDefinition, IDisposable<EffectEntityView>>>(),
                    visualLogicStageSetup.EffectsSetup
                    ));

            container.Bind<ITrySpawnSectionCoinUseCase>()
                .FromFunction(c => new TrySpawnSectionCoinUseCase(
                    c.Resolve<IFactory<CoinEntityViewDefinition, IDisposable<CoinEntityView>>>(),
                    visualLogicStageSetup.CoinsSetup
                    ));

            container.Bind<ITrySpawnRandomSectionElementUseCase>()
                .FromFunction(c => new TrySpawnRandomSectionElementUseCase(
                    visualLogicStageSetup.SectionsSetup,
                    c.Resolve<ITrySpawnRandomSectionEffectUseCase>(),
                    c.Resolve<ITrySpawnSectionCoinUseCase>()
                    ));

            container.Bind<ITrySpawnRandomSectionUseCase>()
                .FromFunction((c) => new TrySpawnRandomSectionUseCase(
                    c.Resolve<IFactory<SectionEntityViewDefinition, IDisposable<SectionEntityView>>>(),
                    c.Resolve<IRepository<IDisposable<SectionEntityView>>>(),
                    stageContextReferences.SectionsStartPosition,
                    visualLogicStageSetup.SectionsSetup,
                    c.Resolve<ITrySpawnRandomSectionElementUseCase>()
                    ));

            container.Bind<IDespawnSectionUseCase>()
                .FromFunction((c) => new DespawnSectionUseCase(
                    c.Resolve<IRepository<IDisposable<SectionEntityView>>>()
                    ));

            container.Bind<IGenerateSectionsUseCase>()
                .FromFunction((c) => new GenerateSectionsUseCase(
                    c.Resolve<ISingleRepository<IDisposable<ShipEntityView>>>(),
                    c.Resolve<IRepository<IDisposable<SectionEntityView>>>(),
                    stageContextReferences.SectionsStartPosition,
                    visualLogicStageSetup.SectionsSetup,
                    stageContextReferences.StageSettings,
                    c.Resolve<ITrySpawnRandomSectionUseCase>()
                    ));

            container.Bind<GenerateSectionsTickable>()
                .FromFunction((c) => new GenerateSectionsTickable(
                    c.Resolve<IGenerateSectionsUseCase>()
                    ))
                .WhenInit((c, o) => tickablesService.AddTickable(o))
                .WhenDispose((o) => tickablesService.RemoveTickable(o));

            container.Bind<ICleanSectionsUseCase>()
                .FromFunction((c) => new CleanSectionsUseCase(
                    c.Resolve<ISingleRepository<IDisposable<ShipEntityView>>>(),
                    c.Resolve<IRepository<IDisposable<SectionEntityView>>>(),
                    stageContextReferences.StageSettings,
                    c.Resolve<IDespawnSectionUseCase>()
                    ));

            container.Bind<CleanSectionsTickable>()
                .FromFunction((c) => new CleanSectionsTickable(
                    c.Resolve<ICleanSectionsUseCase>()
                    ))
                .WhenInit((c, o) => tickablesService.AddTickable(o))
                .WhenDispose((o) => tickablesService.RemoveTickable(o));

            container.Bind<ISetSectionsTickablesActiveUseCase>()
                .FromFunction((c) => new SetSectionsTickablesActiveUseCase(
                    c.Resolve<GenerateSectionsTickable>(),
                    c.Resolve<CleanSectionsTickable>()
                    ));
        }
    }
}
