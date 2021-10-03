using Juce.CoreUnity.Scenes;
using System.Threading.Tasks;

namespace Playground.Contexts.Meta
{
    public static class MetaContextLoader
    {
        public readonly static string SceneName = "MetaContext";

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
