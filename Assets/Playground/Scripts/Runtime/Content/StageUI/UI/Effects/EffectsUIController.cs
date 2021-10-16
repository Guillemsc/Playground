using Juce.Core.Subscribables;

namespace Playground.Content.StageUI.UI.Effects
{
    public class EffectsUIController : ISubscribable
    {
        private readonly EffectsUIViewModel viewModel;

        public EffectsUIController(
            EffectsUIViewModel viewModel
            )
        {
            this.viewModel = viewModel;
        }

        public void Subscribe()
        {

        }

        public void Unsubscribe()
        {

        }
    }
}
