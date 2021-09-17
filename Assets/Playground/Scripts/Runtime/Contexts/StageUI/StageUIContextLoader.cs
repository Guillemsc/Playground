using Juce.CoreUnity.Scenes;
using System.Threading.Tasks;

namespace Playground.Contexts.Stage
{
    public static class StageUIContextLoader
    {
        public readonly static string SceneName = "StageUIContext";

        public static Task Load()
        {
            return new ScenesLoader(SceneName).Load();
        }

        public static Task Unload()
        {
            return new ScenesLoader(SceneName).Unload();
        }
    }
}
