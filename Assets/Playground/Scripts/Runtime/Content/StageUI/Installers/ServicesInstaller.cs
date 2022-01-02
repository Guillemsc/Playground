using Juce.Core.DI.Builder;
using Juce.Core.DI.Installers;
using JuceUnity.Core.DI.Extensions;
using Playground.Services.ViewStack;

namespace Playground.Content.StageUI.Installers
{
    public class ServicesInstaller : IInstaller
    {
        public void Install(IDIContainerBuilder container)
        {
            //container.Bind<UIViewStackService>().FromServicesProvider();
        }
    }
}
