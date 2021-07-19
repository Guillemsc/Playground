using System.Collections.Generic;
using System.Text;

namespace Playground.Persistence
{
    [System.Serializable]
    public class ProgressData
    {
        public const string LocalPath = "ProgressData";

        public int SoftCurrency { get; set; } = 0;
        public int TotalStars { get; set; } = 0;
        public List<string> OwnedCars { get; set; } = new List<string>();
        public List<StageData> StagesData { get; set; } = new List<StageData>();

        public override string ToString()
        {
            StringBuilder ownedCarsStringBuilder = new StringBuilder();

            foreach (string ownedCar in OwnedCars)
            {
                ownedCarsStringBuilder.AppendLine(ownedCar);
            }

            StringBuilder stagesDataStringBuilder = new StringBuilder();

            foreach (StageData data in StagesData)
            {
                stagesDataStringBuilder.AppendLine(data.ToString());
            }

            return
                $"{nameof(SoftCurrency)}:{SoftCurrency} \n" +
                $"{nameof(TotalStars)}:{TotalStars} \n" +
                $"{nameof(OwnedCars)}:{ownedCarsStringBuilder} \n" +
                $"{nameof(StagesData)}:{stagesDataStringBuilder} \n";
        }
    }
}
