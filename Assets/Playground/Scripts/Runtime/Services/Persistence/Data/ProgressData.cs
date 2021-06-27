using System.Collections.Generic;
using System.Text;

namespace Playground.Services
{
    [System.Serializable]
    public class ProgressData
    {
        public const string LocalPath = "ProgressData";

        public int SoftCurrency { get; set; } = 0;
        public List<StageData> StagesData { get; set; } = new List<StageData>();

        public override string ToString()
        {
            StringBuilder stagesDataStringBuilder = new StringBuilder();

            foreach (StageData data in StagesData)
            {
                stagesDataStringBuilder.AppendLine(data.ToString());
            }

            return
                $"{nameof(SoftCurrency)}:{SoftCurrency} \n" +
                $"{nameof(StagesData)}:{stagesDataStringBuilder} \n";
        }
    }
}
