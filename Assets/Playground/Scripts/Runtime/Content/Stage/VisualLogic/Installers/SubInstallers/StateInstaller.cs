using Juce.Core.DI.Builder;
using Playground.Content.Stage.VisualLogic.State;

namespace Playground.Content.Stage.VisualLogic.Installers
{
    public static class StateInstaller
    {
        public static void InstallState(
            this IDIContainerBuilder container
            )
        {
            container.Bind<InputState>().FromNew();
            container.Bind<DirectionSelectionState>().FromNew();
        }
    }
}
