using Juce.Core.Repositories;
using Playground.Cheats.Mechanics;
using Playground.Content.Stage.Logic.Entities;

namespace Playground.Content.Stage.Logic.Cheats.UseCases.ImmortailitySetActiveCheat
{
    public class ImmortailitySetActiveCheatUseCase : IImmortailitySetActiveCheatUseCase
    {
        private readonly IReadOnlySingleRepository<ShipEntity> shipEntityRepository;

        public ImmortailitySetActiveCheatUseCase(
            IReadOnlySingleRepository<ShipEntity> shipEntityRepository
            )
        {
            this.shipEntityRepository = shipEntityRepository;
        }

        public void Execute(bool active)
        {
            bool found = shipEntityRepository.TryGet(out ShipEntity shipEntity);

            if(!found)
            {
                return;
            }

            if (active)
            {
                shipEntity.Mechanics.Immortality.AddUnique(
                    CheatsShipMechanicsConstants.ImmortalityActivationId
                    );
            }
            else
            {
                shipEntity.Mechanics.Immortality.RemoveUnique(
                    CheatsShipMechanicsConstants.ImmortalityActivationId
                    );
            }
        }
    }
}
