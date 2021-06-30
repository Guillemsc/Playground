using System.Threading;
using System.Threading.Tasks;

namespace Playground.Shared.UseCases
{
    public interface ISaveProgressUseCase
    {
        Task Execute(CancellationToken cancellationToken);
    }
}
