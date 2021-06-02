using System.Threading.Tasks;

namespace Playground.Flow.UseCases
{
    public class NopLoadAdsScenesFlowUseCase : ILoadAdsScenesFlowUseCase
    {
        public Task Execute()
        {
            return Task.CompletedTask;
        }
    }
}
