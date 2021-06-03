using Juce.Core.Events;
using Playground.Content.Stage.Logic.Events;

namespace Playground.Content.Stage.VisualLogic.UseCases
{
    public class CarAcceleratesOrBrakesUseCase : ICarAcceleratesOrBrakesUseCase
    {
        private readonly IEventDispatcher eventDispatcher;

        public CarAcceleratesOrBrakesUseCase(IEventDispatcher eventDispatcher)
        {
            this.eventDispatcher = eventDispatcher;
        }

        public void Execute()
        {
            eventDispatcher.Dispatch(new CarAcceleratesOrBrakesInEvent());
        }
    }
}
