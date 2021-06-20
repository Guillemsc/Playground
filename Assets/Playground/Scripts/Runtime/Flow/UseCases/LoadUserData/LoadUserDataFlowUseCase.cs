using Juce.CoreUnity.Service;
using Playground.Services;
using System.Threading.Tasks;

namespace Playground.Flow.UseCases
{
    public class LoadUserDataFlowUseCase :  ILoadUserDataFlowUseCase
    {
        public Task Execute()
        {
            UserService userService = ServicesProvider.GetService<UserService>();

            return userService.Load(default);
        }
    }
}
