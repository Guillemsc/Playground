namespace Playground.Persistence
{
    [System.Serializable]
    public class CarStageData
    {
        public string CarTypeId { get; set; } = string.Empty;
        public int Stars { get; set; } = 0;

        public override string ToString()
        {
            return
                $"{nameof(CarTypeId)}:{CarTypeId} \n" +
                $"{nameof(Stars)}:{Stars} \n";
        }
    }
}
