using Juce.CoreUnity.UI;

namespace Playground.Content.StageUI.UI.DirectionSelector
{
    public interface IDirectionSelectorUIInteractor 
    {
        void SetDirectionSelectionPosition(float normalizedPosition);
        void SetCurrentSelectedPosition(float normalizedPosition);
    }
}
