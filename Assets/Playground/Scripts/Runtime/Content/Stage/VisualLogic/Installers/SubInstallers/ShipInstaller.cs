using Juce.Core.DI.Builder;
using Juce.Core.Disposables;
using Juce.Core.Events;
using Juce.Core.Factories;
using Juce.Core.Repositories;
using Juce.CoreUnity.Services;
using Playground.Content.Stage.VisualLogic.Entities;
using Playground.Content.Stage.VisualLogic.Setup;
using Playground.Content.Stage.VisualLogic.State;
using Playground.Content.Stage.VisualLogic.Stats;
using Playground.Content.Stage.VisualLogic.UseCases.AddEffect;
using Playground.Content.Stage.VisualLogic.UseCases.CreateShipView;
using Playground.Content.Stage.VisualLogic.UseCases.KillShip;
using Playground.Content.Stage.VisualLogic.UseCases.ShipCollided;
using Playground.Content.Stage.VisualLogic.UseCases.ShipCollidedWithCoin;
using Playground.Content.Stage.VisualLogic.UseCases.ShipCollidedWithDeadlyCollision;
using Playground.Content.Stage.VisualLogic.UseCases.ShipCollidedWithEffect;
using Playground.Content.Stage.VisualLogic.UseCases.ShipCollidedWithPointGoal;
using Playground.Content.Stage.VisualLogic.UseCases.StartShip;
using Playground.Content.Stage.VisualLogic.UseCases.StartShipMovement;
using Playground.Content.Stage.VisualLogic.UseCases.StopShipMovement;
using Playground.Content.StageUI.UI.Points;
using Playground.Contexts.Stage;
using Playground.Services;

namespace Playground.Content.Stage.VisualLogic.Installers
{
    public static class ShipInstaller
    {
        public static void InstallShip(
            this IDIContainerBuilder container,
            IEventDispatcher eventDispatcher,
            TickablesService tickablesService,
            TimeService timeService,
            StageVisualLogicSetup visualLogicStageSetup,
            StageContextReferences stageContextReferences
            )
        {
            container.Bind<IFactory<ShipEntityViewDefinition, IDisposable<ShipEntityView>>>()
              .FromFunction((c) => new ShipEntityViewFactory(
                  visualLogicStageSetup.ShipSetup.ShipEntityView,
                  parent: stageContextReferences.ShipParent
                  ));

            container.Bind<ISingleRepository<IDisposable<ShipEntityView>>, SimpleSingleRepository<IDisposable<ShipEntityView>>>()
                .FromNew();

            container.Bind<ShipEntityViewMovementTickable>()
               .FromFunction(c => new ShipEntityViewMovementTickable(
                   timeService,
                   c.Resolve<ShipStats>(),
                   c.Resolve<DirectionSelectionState>()
                   ))
               .WhenInit((c, o) => tickablesService.AddTickable(o))
               .WhenDispose((o) => tickablesService.RemoveTickable(o));

            container.Bind<IStartShipMovementUseCase>()
                .FromFunction((c) => new StartShipMovementUseCase(
                    c.Resolve<ShipEntityViewMovementTickable>()
                    ));

            container.Bind<IStopShipMovementUseCase>()
                .FromFunction((c) => new StopShipMovementUseCase(
                    c.Resolve<ShipEntityViewMovementTickable>()
                    ));

            container.Bind<IStartShipUseCase>()
                .FromFunction(c => new StartShipUseCase(
                    ));

            container.Bind<IKillShipUseCase>()
                .FromFunction(c => new KillShipUseCase(
                    ));

            container.Bind<IShipCollidedWithDeadlyCollisionUseCase>()
                .FromFunction((c) => new ShipCollidedWithDeadlyCollisionUseCase(
                    eventDispatcher
                    ));

            container.Bind<IShipCollidedWithEffectUseCase>()
                .FromFunction(c => new ShipCollidedWithEffectUseCase(
                    c.Resolve<IAddEffectUseCase>()
                    ));

            container.Bind<IShipCollidedWithPointGoalUseCase>()
                .FromFunction(c => new ShipCollidedWithPointGoalUseCase(
                    eventDispatcher,
                    c.Resolve<PointsState>()
                    ));

            container.Bind<IShipCollidedWithCoinUseCase>()
                .FromFunction(c => new ShipCollidedWithCoinUseCase(
                    eventDispatcher
                    ));

            container.Bind<IShipCollidedUseCase>()
                .FromFunction((c) => new ShipCollidedUseCase(
                    c.Resolve<IShipCollidedWithDeadlyCollisionUseCase>(),
                    c.Resolve<IShipCollidedWithEffectUseCase>(),
                    c.Resolve<IShipCollidedWithPointGoalUseCase>(),
                    c.Resolve<IShipCollidedWithCoinUseCase>()
                    ));

            container.Bind<ITryCreateShipViewUseCase>()
                .FromFunction((c) => new TryCreateShipViewUseCase(
                    c.Resolve<IFactory<ShipEntityViewDefinition, IDisposable<ShipEntityView>>>(),
                    c.Resolve<ISingleRepository<IDisposable<ShipEntityView>>>(),
                    stageContextReferences.ShipStartPosition,
                    c.Resolve<IShipCollidedUseCase>()
                    ));
        }
    }
}
