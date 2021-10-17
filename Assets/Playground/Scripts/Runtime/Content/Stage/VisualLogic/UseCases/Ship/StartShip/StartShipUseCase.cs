using Playground.Content.Stage.VisualLogic.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Playground.Content.Stage.VisualLogic.UseCases.StartShip
{
    public class StartShipUseCase : IStartShipUseCase
    {
        public Task Execute(ShipEntityView shipEntityView, CancellationToken cancellationToken)
        {
            return shipEntityView.PlayStart(instantly: false, cancellationToken);
        }
    }
}
