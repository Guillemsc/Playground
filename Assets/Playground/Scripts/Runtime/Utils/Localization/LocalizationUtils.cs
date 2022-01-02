using Juce.CoreUnity.Service;
using Playground.Services;

namespace Playground.Utils.Localization
{
    public static class LocalizationUtils
    {
        public static string GetValue(string tid)
        {
            //bool found = ServicesProvider.TryGetService(out LocalizationService localizationService);

            //if (!found)
            //{
            //    return "Error";
            //}

            //return localizationService.GetValue(tid);

            return "";
        }

        public static string[] GetValues(string[] tids)
        {
            //bool found = ServicesProvider.TryGetService(out LocalizationService localizationService);

            //if (!found)
            //{
            //    return new string[] { "Error" };
            //}

            string[] values = new string[tids.Length];

            //for(int i = 0; i < tids.Length; ++i)
            //{
            //    values[i] = localizationService.GetValue(tids[i]);
            //}

            return values;
        }
    }
}
