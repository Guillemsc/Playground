using Playground.Persistence;
using Playground.Services;

namespace Playground.Content.Shared.UseCases
{
    public class TryGetStageCarStarsUseCase : ITryGetStageCarStarsUseCase
    {
        private readonly PersistenceService persistanceService;

        public TryGetStageCarStarsUseCase(
            PersistenceService persistanceService
            )
        {
            this.persistanceService = persistanceService;
        }

        public bool Execute(string stageTypeId, string carTypeId, out int stars)
        {
            ProgressData progressData = persistanceService.ProgressDataSerializableData.Data;

            bool stageDataFound = ProgressDataUtils.TryGetStageData(progressData, stageTypeId, out StageData stageData);

            if(!stageDataFound)
            {
                stars = default;
                return false;
            }

            bool carStageDataFound = StageDataUtilsUtils.TryGetCarStageData(stageData, carTypeId, out CarStageData carStageData);

            if(!carStageDataFound)
            {
                stars = default;
                return false;
            }

            stars = carStageData.Stars;
            return true;
        }
    }
}
