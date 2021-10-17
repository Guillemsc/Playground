using Playground.Content.Stage.VisualLogic.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Playground.Content.Stage.VisualLogic.UseCases.KillShip
{
    public class KillShipUseCase : IKillShipUseCase
    {
        public Task Execute(ShipEntityView shipEntityView, CancellationToken cancellationToken)
        {
            return shipEntityView.PlayDeath(instantly: false, cancellationToken);
        }
    }
}
