using Juce.Core.Subscribables;
using Playground.Content.StageUI.UI.Coins.UseCases.SetPoints;
using System.Threading;

namespace Playground.Content.StageUI.UI.Coins
{
    public class CoinsUIInteractor : ICoinsUIInteractor, ISubscribable
    {
        private readonly CoinsUIViewModel viewModel;
        private readonly ISetCoinsUseCase setCoinsUseCase;
        public CoinsUIInteractor(
            CoinsUIViewModel viewModel,
            ISetCoinsUseCase setCoinsUseCase
            )
        {
            this.viewModel = viewModel;
            this.setCoinsUseCase = setCoinsUseCase;
        }

        public void Subscribe()
        {
            SetCoins(coins: 0, instantly: true);
        }

        public void Unsubscribe()
        {

        }

        public void SetCoins(int coins, bool instantly = false)
        {
            setCoinsUseCase.Execute(coins, instantly, CancellationToken.None).RunAsync();
        }
    }
}
