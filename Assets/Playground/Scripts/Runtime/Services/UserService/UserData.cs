namespace Playground.Services
{
    [System.Serializable]
    public class UserData
    {
        public const string LocalPath = "UserData";

        public string SelectedCarTypeId { get; set; }

        public override string ToString()
        {
            return 
                $"{nameof(SelectedCarTypeId)}:{SelectedCarTypeId} \n" +
                $"{nameof(SelectedCarTypeId)}:{SelectedCarTypeId} \n";
        }
    }
}
