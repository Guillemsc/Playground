using Juce.CoreUnity.Service;
using Playground.Services;
using System.Threading;
using System.Threading.Tasks;

namespace Playground.Shared.UseCases
{
    public class SaveProgressUseCase : ISaveProgressUseCase
    {
        public Task Execute(CancellationToken cancellationToken)
        {
            PersistenceService persistanceService = ServicesProvider.GetService<PersistenceService>();

            return persistanceService.ProgressDataSerializableData.Save(cancellationToken);
        }
    }
}
