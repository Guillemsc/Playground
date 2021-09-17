using Juce.CoreUnity.Scenes;
using System.Threading.Tasks;

namespace Playground.Contexts.Cameras
{
    public static class CamerasContextLoader
    {
        public readonly static string SceneName = "CamerasContext";

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
