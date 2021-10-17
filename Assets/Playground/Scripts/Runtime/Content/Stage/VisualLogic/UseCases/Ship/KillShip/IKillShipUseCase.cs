using Playground.Content.Stage.VisualLogic.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Playground.Content.Stage.VisualLogic.UseCases.KillShip
{
    public interface IKillShipUseCase
    {
        Task Execute(ShipEntityView shipEntityView, CancellationToken cancellationToken);
    }
}
