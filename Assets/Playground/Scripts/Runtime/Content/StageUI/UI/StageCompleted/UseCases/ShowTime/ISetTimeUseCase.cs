using System;

namespace Playground.Content.StageUI.UI.StageCompleted
{
    public interface ISetTimeUseCase
    {
        void Execute(TimeSpan timeSpan);
    }
}
