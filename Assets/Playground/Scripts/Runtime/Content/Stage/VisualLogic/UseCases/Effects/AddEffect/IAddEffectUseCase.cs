using Playground.Configuration.Stage;
using Playground.Content.Stage.VisualLogic.Entities;

namespace Playground.Content.Stage.VisualLogic.UseCases.AddEffect
{
    public interface IAddEffectUseCase
    {
        void Execute(EffectEntityView effectEntityView);
    }
}
