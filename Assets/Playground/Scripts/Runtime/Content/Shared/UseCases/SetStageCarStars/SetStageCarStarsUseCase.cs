using Playground.Persistence;
using Playground.Services;
using System.Threading;
using System.Threading.Tasks;

namespace Playground.Content.Shared.UseCases
{
    public class SetStageCarStarsUseCase : ISetStageCarStarsUseCase
    {
        private readonly PersistenceService persistanceService;

        public SetStageCarStarsUseCase(
            PersistenceService persistanceService
            )
        {
            this.persistanceService = persistanceService;
        }

        public Task Execute(string stageTypeId, string carTypeId, int starsToSet, CancellationToken cancellationToken)
        {
            ProgressData progressData = persistanceService.ProgressDataSerializableData.Data;

            ProgressDataUtils.GetOrCreateStageData(progressData, stageTypeId, out StageData stageData);
            StageDataUtilsUtils.GetOrCreateCarStageData(stageData, carTypeId, out CarStageData carStageData);

            carStageData.Stars = starsToSet;

            ProgressDataUtils.UpdateTotalStars(progressData);

            return persistanceService.ProgressDataSerializableData.Save(cancellationToken);
        }
    }
}
