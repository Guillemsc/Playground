using System.Threading;
using System.Threading.Tasks;

namespace Playground.Content.StageUI.UI.Effects.UseCases.SetPoints
{
    public interface ISetPointsUseCase
    {
        Task Execute(
            int points,
            bool instantly,
            CancellationToken cancellationToken
            );
    }
}
