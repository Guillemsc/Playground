using System.Threading.Tasks;

namespace Playground.Flow.UseCases
{
    public class NopUnloadMetaFlowUseCase : IUnloadMetaFlowUseCase
    {
        public Task Execute()
        {
            return Task.CompletedTask;
        }
    }
}
