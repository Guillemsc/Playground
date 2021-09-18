using Juce.Core.Disposables;
using Juce.Core.Factories;
using Juce.Core.Repositories;
using Playground.Content.Stage.Logic.Snapshots;
using Playground.Content.Stage.VisualLogic.Entities;

namespace Playground.Content.Stage.VisualLogic.UseCases.CreateShipView
{
    public class TryCreateShipViewUseCase : ITryCreateShipViewUseCase
    {
        private readonly IFactory<ShipEntityViewDefinition, IDisposable<ShipEntityView>> shipEntityViewFactory;
        private readonly IKeyValueRepository<int, IDisposable<ShipEntityView>> shipEntityViewRepository;

        public TryCreateShipViewUseCase(
            IFactory<ShipEntityViewDefinition, IDisposable<ShipEntityView>> shipEntityViewFactory,
            IKeyValueRepository<int, IDisposable<ShipEntityView>> shipEntityViewRepository
            )
        {
            this.shipEntityViewFactory = shipEntityViewFactory;
            this.shipEntityViewRepository = shipEntityViewRepository;
        }

        public bool Execute(
            ShipEntitySnapshot shipEntitySnapshot,
            out IDisposable<ShipEntityView> shipEntityView
            )
        {
            ShipEntityViewDefinition definition = new ShipEntityViewDefinition(
                shipEntitySnapshot.InstanceId
                );

            bool created = shipEntityViewFactory.TryCreate(
                definition,
                out shipEntityView
                );

            if(!created)
            {
                return false;
            }

            shipEntityViewRepository.Add(shipEntityView.Value.InstanceId, shipEntityView);

            return true;
        }
    }
}
