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
using Playground.Content.Stage.Logic.UseCases.ShipCollidedWithDeadlyCollision;

namespace Playground.Content.Stage.Logic.Installers
{
    public class UseCasesInstaller : IInstaller
    {
        public void Install(IDIContainerBuilder containerBuilder)
        {
            containerBuilder.Bind<StageState>().FromNew();

            containerBuilder.Bind<IIdGenerator, IncrementalIdGenerator>().FromNew();

            containerBuilder.Bind<IFactory<ShipLogicSetup, ShipEntity>>()
                .FromFunction((c) => new ShipEntityFactory(
                    c.Resolve<IIdGenerator>()
                    ));

            containerBuilder.Bind<ISingleRepository<ShipEntity>> ()
                .FromFunction((c) => new SimpleSingleRepository<ShipEntity>());

            containerBuilder.Bind<ITryCreateShipUseCase>()
                .FromFunction((c) => new TryCreateShipUseCase(
                    c.Resolve<IFactory<ShipLogicSetup, ShipEntity>>(),
                    c.Resolve<ISingleRepository<ShipEntity>>()
                    ));

            containerBuilder.Bind<ISetupStageUseCase>()
                .FromFunction((c) => new SetupStageUseCase(
                    c.Resolve<IEventDispatcher>(),
                    c.Resolve<StageLogicSetup>(),
                    c.Resolve<StageState>(),
                    c.Resolve<ITryCreateShipUseCase>()
                    ));

            containerBuilder.Bind<IStartStageUseCase>()
                .FromFunction((c) => new StartStageUseCase(
                    c.Resolve<IEventDispatcher>(),
                    c.Resolve<StageState>(),
                    c.Resolve<ISingleRepository<ShipEntity>>()
                    ));

            containerBuilder.Bind<IShipCollidedWithDeadlyCollisionUseCase>()
                .FromFunction((c) => new ShipCollidedWithDeadlyCollisionUseCase(
                    c.Resolve<IEventDispatcher>(),
                    c.Resolve<ISingleRepository<ShipEntity>>()
                    ));
        }
    }
}
