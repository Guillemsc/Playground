namespace Playground.Persistence
{
    public static class ProgressDataUtils
    {
        public static bool TryGetStageData(ProgressData progressData, string stageTypeId, out StageData foundStageData)
        {
            foreach(StageData stageData in progressData.StagesData)
            {
                if(string.Equals(stageTypeId, stageData.StageTypeId))
                {
                    foundStageData = stageData;
                    return true;
                }
            }

            foundStageData = default;
            return false;
        }

        public static void GetOrCreateStageData(ProgressData progressData, string stageTypeId, out StageData stageData)
        {
            bool found = TryGetStageData(progressData, stageTypeId, out stageData);

            if (found)
            {
                return;
            }

            stageData = new StageData()
            {
                StageTypeId = stageTypeId
            };

            progressData.StagesData.Add(stageData);
        }

        public static void UpdateTotalStars(ProgressData progressData)
        {
            int stars = 0;

            foreach(StageData stageData in progressData.StagesData)
            {
                foreach (CarStageData carStageData in stageData.CarStageData)
                {
                    stars += carStageData.Stars;
                }
            }

            progressData.TotalStars = stars;
        }
    }
}
