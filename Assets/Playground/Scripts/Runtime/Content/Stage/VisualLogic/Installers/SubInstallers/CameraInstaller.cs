using Juce.Core.DI.Builder;
using Playground.Content.Stage.VisualLogic.Setup;
using Playground.Content.Stage.VisualLogic.UseCases.ModifyCameraOnceStarts;
using Playground.Content.Stage.VisualLogic.UseCases.SetupCamera;
using Playground.Contexts.Stage;

namespace Playground.Content.Stage.VisualLogic.Installers
{
    public static class CameraInstaller
    {
        public static void InstallCamera(
            this IDIContainerBuilder container,
            StageContextInstance stageContextReferences
            )
        {
            container.Bind<ISetupCameraUseCase>()
                .FromFunction((c) => new SetupCameraUseCase(
                    stageContextReferences.CinemachineVirtualCamera,
                    stageContextReferences.CameraStartingTarget
                    ));

            container.Bind<IModifyCameraOnceStartsUseCase>()
                .FromFunction((c) => new ModifyCameraOnceStartsUseCase(
                    stageContextReferences.CinemachineVirtualCamera
                    ));
        }
    }
}
