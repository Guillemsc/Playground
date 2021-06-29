using Juce.CoreUnity.Service;
using Playground.Persistence;
using Playground.Services;

namespace Playground.Shared.UseCases
{
    public class TryGetStageCarStarsUseCase : ITryGetStageCarStarsUseCase
    {
        public bool Execute(string stageTypeId, string carTypeId, out int stars)
        {
            PersistenceService persistanceService = ServicesProvider.GetService<PersistenceService>();

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
