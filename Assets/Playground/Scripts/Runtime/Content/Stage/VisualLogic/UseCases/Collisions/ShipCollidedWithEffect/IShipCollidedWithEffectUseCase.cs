using Playground.Content.Stage.VisualLogic.Entities;

namespace Playground.Content.Stage.VisualLogic.UseCases.ShipCollidedWithEffect
{
    public interface IShipCollidedWithEffectUseCase
    {
        void Execute(EffectEntityView effectEntityView);
    }
}
