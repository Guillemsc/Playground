using Juce.CoreUnity.Physics;
using Playground.Content.Stage.VisualLogic.Entities;

namespace Playground.Content.Stage.VisualLogic.UseCases.ShipCollided
{
    public interface IShipCollidedUseCase
    {
        void Execute(ShipEntityView shipEntityView, Collider2DData collider2DData);
    }
}
