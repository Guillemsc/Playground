using Juce.CoreUnity.UI;

namespace Playground.Content.StageUI.UI.Points
{
    public interface IPointsUIInteractor 
    {
        void SetPoints(int points, bool instantly = false); 
    }
}
