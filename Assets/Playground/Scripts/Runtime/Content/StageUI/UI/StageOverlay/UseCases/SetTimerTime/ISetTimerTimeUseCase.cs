using System;

namespace Playground.Content.StageUI.UI.StageOverlay.UseCases
{
    public interface ISetTimerTimeUseCase
    {
        void Execute(TimeSpan timeSpan);
    }
}
