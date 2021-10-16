using Playground.Configuration.Stage;
using Playground.Content.Stage.VisualLogic.Entities;
using Playground.Content.Stage.VisualLogic.UseCases.AddEffect;

namespace Playground.Content.Stage.VisualLogic.UseCases.ShipCollidedWithEffect
{
    public class ShipCollidedWithEffectUseCase : IShipCollidedWithEffectUseCase
    {
        private readonly IAddEffectUseCase addEffectUseCase;

        public ShipCollidedWithEffectUseCase(
            IAddEffectUseCase addEffectUseCase
            )
        {
            this.addEffectUseCase = addEffectUseCase;
        }

        public void Execute(EffectEntityView effectEntityView)
        {
            effectEntityView.Despawn();

            if(effectEntityView.EffectConfiguration == null)
            {
                UnityEngine.Debug.LogError($"Null {nameof(EffectConfiguration)}, " +
                    $"at {effectEntityView}", effectEntityView.gameObject);
                return;
            }

            addEffectUseCase.Execute(effectEntityView.EffectConfiguration);
        }
    }
}
