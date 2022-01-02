namespace Playground.Services.Configuration
{
    public class CheatsService : ICheatsService
    {
        public void Add(object cheatObject)
        {
            SRDebug.Instance.AddOptionContainer(cheatObject);
        }

        public void Remove(object cheatObject)
        {
            SRDebug.Instance.RemoveOptionContainer(cheatObject);
        }
    }
}
