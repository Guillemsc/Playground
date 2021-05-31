using Juce.Core.Observables;
using System;

namespace Playground.Content.StageUI.UI.StageOverlay
{
    public class StageOverlayUIViewModel
    {
        public ObservableCommand SettingsCommand { get; } = new ObservableCommand();
        public ObservableCommand RestartCommand { get; } = new ObservableCommand();

        public Action RegisteredRestartCallbacks { get; set; }
    }
}
