using System.Threading;
using System.Threading.Tasks;

namespace Playground.Content.StageUI.UI.Coins.UseCases.SetPoints
{
    public interface ISetCoinsUseCase
    {
        Task Execute(
            int coins,
            bool instantly,
            CancellationToken cancellationToken
            );
    }
}
