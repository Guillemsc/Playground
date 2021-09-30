using Juce.Core.Disposables;
using Juce.Core.Factories;
using Juce.Core.Repositories;
using Playground.Content.Stage.Logic.Snapshots;
using Playground.Content.Stage.VisualLogic.Entities;
using Playground.Content.Stage.VisualLogic.UseCases.ShipCollided;
using UnityEngine;

namespace Playground.Content.Stage.VisualLogic.UseCases.CreateShipView
{
    public class TryCreateShipViewUseCase : ITryCreateShipViewUseCase
    {
        private readonly IFactory<ShipEntityViewDefinition, IDisposable<ShipEntityView>> shipEntityViewFactory;
        private readonly ISingleRepository<IDisposable<ShipEntityView>> shipEntityViewRepository;
        private readonly Transform shipStartPosition;
        private readonly IShipCollidedUseCase shipCollidedUseCase;

        public TryCreateShipViewUseCase(
            IFactory<ShipEntityViewDefinition, IDisposable<ShipEntityView>> shipEntityViewFactory,
            ISingleRepository<IDisposable<ShipEntityView>> shipEntityViewRepository,
            Transform shipStartPosition,
            IShipCollidedUseCase shipCollidedUseCase
            )
        {
            this.shipEntityViewFactory = shipEntityViewFactory;
            this.shipEntityViewRepository = shipEntityViewRepository;
            this.shipStartPosition = shipStartPosition;
            this.shipCollidedUseCase = shipCollidedUseCase;
        }

        public bool Execute(
            ShipEntitySnapshot shipEntitySnapshot,
            out IDisposable<ShipEntityView> shipEntityView
            )
        {
            ShipEntityViewDefinition definition = new ShipEntityViewDefinition(
                shipEntitySnapshot.InstanceId,
                shipStartPosition.position
                );

            bool created = shipEntityViewFactory.TryCreate(
                definition,
                out shipEntityView
                );

            if(!created)
            {
                return false;
            }

            shipEntityViewRepository.Set(shipEntityView);

            shipEntityView.Value.OnTrigger += shipCollidedUseCase.Execute;

            return true;
        }
    }
}
