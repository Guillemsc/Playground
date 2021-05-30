using Juce.CoreUnity.Contexts;

namespace Playground.Contexts
{
    public class CameraContext : Context
    {
        public readonly static string SceneName = "CameraContext";

        protected override void Init()
        {
            ContextsProvider.Register(this);
        }

        protected override void CleanUp()
        {
            ContextsProvider.Unregister(this);
        }
    }
}
