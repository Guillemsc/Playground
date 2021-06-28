namespace Playground.Persistence
{
    public static class StageDataUtilsUtils
    {
        public static bool TryGetCarStageData(StageData stageData, string carTypeId, out CarStageData foundCarStageData)
        {
            foreach (CarStageData carStageData in stageData.CarStageData)
            {
                if (string.Equals(carTypeId, carStageData.CarTypeId))
                {
                    foundCarStageData = carStageData;
                    return true;
                }
            }

            foundCarStageData = default;
            return false;
        }

        public static void GetOrCreateCarStageData(StageData stageData, string carTypeId, out CarStageData carStageData)
        {
            bool found = TryGetCarStageData(stageData, carTypeId, out carStageData);

            if(found)
            {
                return;
            }

            carStageData = new CarStageData()
            {
                CarTypeId = carTypeId
            };

            stageData.CarStageData.Add(carStageData);
        }
    }
}
