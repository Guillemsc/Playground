using Juce.Core.Events;
using Juce.Core.Factories;
using Juce.Core.Id;
using Juce.Core.Repositories;
using Juce.Core.DI.Builder;
using Juce.Core.DI.Installers;
using Playground.Content.Stage.Logic.Entities;
using Playground.Content.Stage.Logic.Setup;
using Playground.Content.Stage.Logic.UseCases.TryCreateShip;
using Playground.Content.Stage.Logic.UseCases.SetupStage;
using Playground.Content.Stage.Logic.UseCases.StartStage;
using Playground.Content.Stage.Logic.State;

namespace Playground.Content.Stage.Logic.Installers
{
    public class UseCasesInstaller : IInstaller
    {
        public void Install(IDIContainerBuilder containerBuilder)
        {
            containerBuilder.Bind<StageState>().FromNew();

            containerBuilder.Bind<IIdGenerator, IncrementalIdGenerator>().FromNew();

            containerBuilder.Bind<IFactory<LogicShipSetup, ShipEntity>>()
                .FromFunction((c) => new ShipEntityFactory(
                    c.Resolve<IIdGenerator>()
                    ));

            containerBuilder.Bind<IKeyValueRepository<int, ShipEntity>>()
                .FromFunction((c) => new SimpleKeyValueRepository<int, ShipEntity>());

            containerBuilder.Bind<ITryCreateShipUseCase>()
                .FromFunction((c) => new TryCreateShipUseCase(
                    c.Resolve<IFactory<LogicShipSetup, ShipEntity>>(),
                    c.Resolve<IKeyValueRepository<int, ShipEntity>>()
                    ));

            containerBuilder.Bind<ISetupStageUseCase>()
                .FromFunction((c) => new SetupStageUseCase(
                    c.Resolve<IEventDispatcher>(),
                    c.Resolve<LogicStageSetup>(),
                    c.Resolve<StageState>(),
                    c.Resolve<ITryCreateShipUseCase>()
                    ));

            containerBuilder.Bind<IStartStageUseCase>()
                .FromFunction((c) => new StartStageUseCase(
                    c.Resolve<IEventDispatcher>(),
                    c.Resolve<StageState>(),
                    c.Resolve<IKeyValueRepository<int, ShipEntity>>()
                    ));
        }
    }
}
