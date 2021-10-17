using Playground.Content.Stage.VisualLogic.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Playground.Content.Stage.VisualLogic.UseCases.StartShip
{
    public interface IStartShipUseCase
    {
        Task Execute(ShipEntityView shipEntityView, CancellationToken cancellationToken);
    }
}
