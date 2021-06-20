using System.Threading.Tasks;

namespace Playground.Flow.UseCases
{
    public class NopLoadUserDataFlowUseCase : ILoadUserDataFlowUseCase
    {
        public Task Execute()
        {
            return Task.CompletedTask;
        }
    }
}
