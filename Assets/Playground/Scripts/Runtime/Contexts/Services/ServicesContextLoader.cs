using Juce.CoreUnity.Scenes;
using System.Threading.Tasks;

namespace Playground.Contexts.Services
{
    public static class ServicesContextLoader 
    {
        public readonly static string SceneName = "ServicesContext";

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
