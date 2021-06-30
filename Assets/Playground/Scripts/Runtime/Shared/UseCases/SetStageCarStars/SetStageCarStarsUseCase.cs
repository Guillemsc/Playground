using Juce.CoreUnity.Service;
using Playground.Persistence;
using Playground.Services;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Playground.Shared.UseCases
{
    public class SetStageCarStarsUseCase : ISetStageCarStarsUseCase
    {
        public void Execute(string stageTypeId, string carTypeId, int starsToSet)
        {
            PersistenceService persistanceService = ServicesProvider.GetService<PersistenceService>();

            ProgressData progressData = persistanceService.ProgressDataSerializableData.Data;

            ProgressDataUtils.GetOrCreateStageData(progressData, stageTypeId, out StageData stageData);
            StageDataUtilsUtils.GetOrCreateCarStageData(stageData, carTypeId, out CarStageData carStageData);

            starsToSet = Math.Max(starsToSet, 0);

            carStageData.Stars = starsToSet;

            ProgressDataUtils.UpdateTotalStars(progressData);
        }
    }
}
