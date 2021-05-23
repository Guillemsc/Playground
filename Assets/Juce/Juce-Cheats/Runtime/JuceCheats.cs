using Juce.Cheats.Definition;
using Juce.Utils.Singletons;

namespace Juce.Cheats
{
    public class JuceCheats : Singleton<JuceCheats>
    {
        public CheatsDefinition CheatsDefinition { get; } = new CheatsDefinition();
    }
}
