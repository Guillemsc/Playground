using System.Threading;
using System.Threading.Tasks;

namespace Playground.Shared.UseCases
{
    public class NopSetStageCarStarsUseCase : ISetStageCarStarsUseCase
    {
        public Task Execute(string stageTypeId, string carTypeId, int starsToSet, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
