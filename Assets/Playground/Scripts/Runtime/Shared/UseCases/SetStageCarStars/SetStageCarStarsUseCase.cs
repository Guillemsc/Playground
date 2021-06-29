using Juce.CoreUnity.Service;
using Playground.Persistence;
using Playground.Services;
using System.Threading;
using System.Threading.Tasks;

namespace Playground.Shared.UseCases
{
    public class SetStageCarStarsUseCase : ISetStageCarStarsUseCase
    {
        public Task Execute(string stageTypeId, string carTypeId, int starsToSet, CancellationToken cancellationToken)
        {
            PersistenceService persistanceService = ServicesProvider.GetService<PersistenceService>();

            ProgressData progressData = persistanceService.ProgressDataSerializableData.Data;

            ProgressDataUtils.GetOrCreateStageData(progressData, stageTypeId, out StageData stageData);
            StageDataUtilsUtils.GetOrCreateCarStageData(stageData, carTypeId, out CarStageData carStageData);

            carStageData.Stars = starsToSet;

            ProgressDataUtils.UpdateTotalStars(progressData);

            return persistanceService.ProgressDataSerializableData.Save(cancellationToken);
        }
    }
}
