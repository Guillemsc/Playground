using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Playground.Services.Localization
{
    public interface ILocalizationService
    {
        event Action OnLanguageChanged;

        IReadOnlyList<string> Languages { get; }
        int CurrentLanguageIndex { get; }

        Task<bool> Load();

        void SetLanguage(int languageIndex);
        void SetLanguage(string language);

        string GetValue(string tid, params string[] args);
    }
}
