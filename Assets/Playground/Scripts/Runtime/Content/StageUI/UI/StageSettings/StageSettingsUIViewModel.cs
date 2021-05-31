using Juce.Core.Observables;
using System;

namespace Playground.Content.StageUI.UI.StageSettings
{
    public class StageSettingsUIViewModel
    {
        public ObservableCommand ClosePanelCommand { get; } = new ObservableCommand();
        public ObservableCommand ExitStageCommand { get; } = new ObservableCommand();

        public Action RegisteredExitStageCallbacks { get; set; }
    }
}
