using System.Threading;
using System.Threading.Tasks;

namespace Playground.Shared.UseCases
{
    public class NopSaveProgressUseCase : ISaveProgressUseCase
    {
        public Task Execute(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
