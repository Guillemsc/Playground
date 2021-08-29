using Juce.CoreUnity.Scenes;
using System.Threading.Tasks;

namespace Playground.Contexts.Stage
{
    public static class StageContextLoader
    {
        public readonly static string SceneName = "StageContext";

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
