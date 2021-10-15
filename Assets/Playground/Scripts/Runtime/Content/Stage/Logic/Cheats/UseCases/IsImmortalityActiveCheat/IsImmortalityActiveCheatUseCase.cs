using Juce.Core.Repositories;
using Playground.Cheats.Mechanics;
using Playground.Content.Stage.Logic.Entities;

namespace Playground.Content.Stage.Logic.Cheats.UseCases.IsImmortalityActiveCheat
{
    public class IsImmortalityActiveCheatUseCase : IIsImmortalityActiveCheatUseCase
    {
        private readonly IReadOnlySingleRepository<ShipEntity> shipEntityRepository;

        public IsImmortalityActiveCheatUseCase(
            IReadOnlySingleRepository<ShipEntity> shipEntityRepository
            )
        {
            this.shipEntityRepository = shipEntityRepository;
        }

        public bool Execute()
        {
            bool found = shipEntityRepository.TryGet(out ShipEntity shipEntity);

            if (!found)
            {
                return false;
            }

            return shipEntity.Mechanics.Immortality.HasUnique(CheatsShipMechanicsConstants.ImmortalityActivationId);
        }
    }
}
