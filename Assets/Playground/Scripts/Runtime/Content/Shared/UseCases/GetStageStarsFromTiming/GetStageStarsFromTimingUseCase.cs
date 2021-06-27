using Playground.Configuration.Stage;

namespace Playground.Content.Shared.UseCases
{
    public class GetStageStarsFromTimingUseCase : IGetStageStarsFromTimingUseCase
    {
        public int Execute(
            StageStarsConfiguration stageStarsConfiguration,
            string carTypeId,
            float seconds
            )
        {
            if (stageStarsConfiguration == null)
            {
                UnityEngine.Debug.LogError($"Tried to get stars from timing, but {nameof(StageStarsConfiguration)} was null " +
                    $"at {nameof(GetStageStarsFromTimingUseCase)}");
                return 0;
            }

            bool stageCarStarsFound = stageStarsConfiguration.TryGet(
                carTypeId,
                out StageStarsCarConfiguration stageStarsCarConfiguration
                );

            if (!stageCarStarsFound)
            {
                UnityEngine.Debug.LogError($"Tried to get stars from timing, but {nameof(StageStarsCarConfiguration)} was not " +
                    $"found for car {carTypeId}. Using default, at {nameof(GetStageStarsFromTimingUseCase)}");

                stageStarsCarConfiguration = stageStarsConfiguration.GetDefault(carTypeId);
            }

            if (seconds <= stageStarsCarConfiguration.Star3Timing)
            {
                return 3;
            }

            if (seconds <= stageStarsCarConfiguration.Star2Timing)
            {
                return 2;
            }

            if (seconds <= stageStarsCarConfiguration.Star1Timing)
            {
                return 1;
            }

            return 0;
        }
    }
}
