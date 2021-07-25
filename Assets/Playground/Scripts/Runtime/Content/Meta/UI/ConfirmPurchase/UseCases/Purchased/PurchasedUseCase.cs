namespace Playground.Content.Meta.UI.ConfirmPurchase
{
    public class PurchasedUseCase : IPurchasedUseCase
    {
        private readonly EventsData eventsData;

        public PurchasedUseCase(EventsData eventsData)
        {
            this.eventsData = eventsData;
        }

        public void Execute()
        {
            eventsData.OnPurchased.Invoke();
        }
    }
}
