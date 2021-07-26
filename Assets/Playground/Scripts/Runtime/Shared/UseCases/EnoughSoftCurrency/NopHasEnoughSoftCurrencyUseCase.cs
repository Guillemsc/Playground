namespace Playground.Shared.UseCases
{
    public class NopHasEnoughSoftCurrencyUseCase : IHasEnoughSoftCurrencyUseCase
    {
        public bool Execute(int value)
        {
            return false;
        }
    }
}
