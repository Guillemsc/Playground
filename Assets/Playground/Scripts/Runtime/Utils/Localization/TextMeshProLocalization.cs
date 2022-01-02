using Juce.CoreUnity.Service;
using Playground.Services;
using Playground.Services.Localization;
using UnityEngine;

namespace Playground.Utils.Localization
{
    public class TextMeshProLocalization : MonoBehaviour
    {
        [SerializeField] private bool disabled = default;

        [Header("Setup")]
        [SerializeField] private string[] tids = default;
        [SerializeField] private string formating = "{0}";

        private TMPro.TextMeshProUGUI text;

        private void Awake()
        {
            Refresh();
            TryRegisterLanguageChange();
        }

        private void OnDestroy()
        {
            TryUnregisterLanguageChange();
        }

        private void TryGetComponent()
        {
            if(text != null)
            {
                return;
            }

            text = gameObject.GetComponent<TMPro.TextMeshProUGUI>();
        }

        private void TryRegisterLanguageChange()
        {
            //bool found = ServicesProvider.TryGetService(out LocalizationService localizationService);

            //if (!found)
            //{
            //    return;
            //}

            //localizationService.OnLanguageChanged += OnLanguageChanged;
        }

        private void TryUnregisterLanguageChange()
        {
            if(ServicesProvider.InstanceWasDestroyed)
            {
                return;
            }

            //bool found = ServicesProvider.TryGetService(out LocalizationService localizationService);

            //if (!found)
            //{
            //    return;
            //}

            //localizationService.OnLanguageChanged -= OnLanguageChanged;
        }

        private void Refresh()
        {
            if(disabled)
            {
                return;
            }

            TryGetComponent();

            if (text == null)
            {
                return;
            }

            //bool found = ServicesProvider.TryGetService(out LocalizationService localizationService);

            //if(!found)
            //{
            //    return;
            //}

            //text.text = GetLocalizedText(localizationService);
        }

        private string GetLocalizedText(LocalizationService localizationService)
        {
            string[] values = LocalizationUtils.GetValues(tids);

            string finalText = string.Format(formating, values);

            return finalText;
        }

        private void OnLanguageChanged()
        {
            Refresh();
        }
    }
}
