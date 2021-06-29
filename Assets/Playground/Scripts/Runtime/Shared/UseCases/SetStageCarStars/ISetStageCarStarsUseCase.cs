using System.Threading;
using System.Threading.Tasks;

namespace Playground.Shared.UseCases
{
    public interface ISetStageCarStarsUseCase
    {
        Task Execute(string stageTypeId, string carTypeId, int starsToSet, CancellationToken cancellationToken);
    }
}
