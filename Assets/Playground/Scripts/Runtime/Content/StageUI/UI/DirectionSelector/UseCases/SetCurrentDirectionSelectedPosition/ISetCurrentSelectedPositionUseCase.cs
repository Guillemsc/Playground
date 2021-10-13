namespace Playground.Content.StageUI.UI.ActionInputDetection.UseCases.SetCurrentSelectedPosition
{
    public interface ISetCurrentSelectedPositionUseCase
    {
        void Execute(float normalizedPosition, bool instantly = false);
    }
}
