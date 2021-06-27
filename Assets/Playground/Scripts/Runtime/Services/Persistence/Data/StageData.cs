using System.Collections.Generic;
using System.Text;

namespace Playground.Services
{
    [System.Serializable]
    public class StageData
    {
        public string StageTypeId { get; set; } = string.Empty;
        public bool Unlocked { get; set; } = false;
        public List<CarStageData> CarStageData { get; set; } = new List<CarStageData>();

        public override string ToString()
        {
            StringBuilder carStageDataStringBuilder = new StringBuilder();

            foreach(CarStageData data in CarStageData)
            {
                carStageDataStringBuilder.AppendLine(data.ToString());
            }

            return
                $"{nameof(StageTypeId)}:{StageTypeId} \n" +
                $"{nameof(Unlocked)}:{Unlocked} \n" +
                $"{nameof(CarStageData)}:{carStageDataStringBuilder} \n";
        }
    }
}
