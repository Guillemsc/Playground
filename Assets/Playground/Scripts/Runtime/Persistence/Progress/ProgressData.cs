namespace Playground.Persistence
{
    [System.Serializable]
    public class ProgressData
    {
        public const string LocalPath = "ProgressData";

        public int BestPoints { get; set; } = 0;

        public override string ToString()
        {
            return
                $"{nameof(BestPoints)}:{BestPoints} \n";
        }
    }
}
