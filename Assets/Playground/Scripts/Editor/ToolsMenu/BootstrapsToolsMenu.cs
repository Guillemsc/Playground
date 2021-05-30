using Juce.CoreUnity.Scenes;
using UnityEditor;
using UnityEditor.SceneManagement;

namespace Playground.ToolsMenu
{
    public static class BootstrapsToolsMenu
    {
        private const string MainBootstrapSceneName = "MainBootstrap";
        private const string StageBootstrapSceneName = "StageBootstrap";

        [MenuItem("Tools/Playground/Main Bootstrap")]
        private static void MainBooststrap()
        {
            ScenesUtils.OpenScene(MainBootstrapSceneName);
        }

        [MenuItem("Tools/Playground/Stage Bootstrap")]
        private static void StageBooststrap()
        {
            ScenesUtils.OpenScene(StageBootstrapSceneName);
        }
    }
}
