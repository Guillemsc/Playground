using Juce.CoreUnity.Service;
using Juce.Loc.Data;
using Juce.Loc.Requests;
using Juce.Loc.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Playground.Services
{
    public class LocalizationService : IService
    {
        public static string DefaultLanguage = "english";

        private LocalizationData localizationData;
        private LanguageLocalizationData languageLocalizationData;

        public IReadOnlyList<string> Languages { get; private set; } = Array.Empty<string>();
        public int CurrentLanguageIndex { get; private set; }

        public event Action OnLanguageChanged;

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

            GetLanguages();

            return true;
        }

        private void GetLanguages()
        {
            if (localizationData == null)
            {
                return;
            }

            Languages = localizationData.Values.Select(i => i.Language).ToArray();
        }

        public void SetLanguage(int languageIndex)
        {
            if(languageIndex >= Languages.Count)
            {
                return;
            }

            string language = Languages[languageIndex];

            SetLanguage(language);
        }

        public void SetLanguage(string language)
        {
            if (localizationData == null)
            {
                UnityEngine.Debug.LogError($"Tried to set language {language} but localization data " +
                    $"is not loaded, at {nameof(LocalizationService)}");
                return;
            }

            for (int i = 0; i < localizationData.Values.Count; ++i)
            {
                LanguageLocalizationData value = localizationData.Values[i];

                if (string.Equals(value.Language, language))
                {
                    languageLocalizationData = value;
                    CurrentLanguageIndex = i;

                    OnLanguageChanged?.Invoke();

                    UnityEngine.Debug.Log($"Language set to {language}");
                    return;
                }
            }

            UnityEngine.Debug.LogError($"Tried to set language {language} but it could not be found, " +
                $"at {nameof(LocalizationService)}");
        }

        public string GetValue(string tid, params string[] args)
        {
            if(languageLocalizationData == null)
            {
                return "Error";
            }

            bool found = languageLocalizationData.Values.TryGetValue(tid, out string value);

            if(!found)
            {
                return $"{tid} not found";
            }

            return string.Format(value, args);
        }
    }
}
