using Juce.CoreUnity.Service;
using Juce.Loc.Data;
using Juce.Loc.Requests;
using Juce.Loc.Results;
using System.Threading.Tasks;

namespace Playground.Services
{
    public class LocalizationService : IService
    {
        private LocalizationData localizationData;

        public LocalizationService()
        {
          
        }

        public void Init()
        {

        }

        public void CleanUp()
        {

        }

        public async Task<bool> Load()
        {
            TaskResult<LocalizationData> localizationDataResult = await LoadLocalizationDataRequest.Execute();

            if(!localizationDataResult.HasResult)
            {
                return false;
            }

            localizationData = localizationDataResult.Value;

            return true;
        }
    }
}
