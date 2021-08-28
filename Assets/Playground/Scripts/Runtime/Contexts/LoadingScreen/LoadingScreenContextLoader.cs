using Juce.CoreUnity.Scenes;
using System.Threading.Tasks;

namespace Playground.Contexts.LoadingScreen
{
    public static class LoadingScreenContextLoader 
    {
        public readonly static string SceneName = "LoadingScreenContext";

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
