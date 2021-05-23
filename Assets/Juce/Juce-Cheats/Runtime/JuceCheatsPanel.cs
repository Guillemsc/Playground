using Juce.Cheats.Binder;
using Juce.Cheats.UIViews;
using UnityEngine;

namespace Juce.Cheats
{
    public class JuceCheatsPanel : MonoBehaviour
    {
        [SerializeField] private DefautUIViewPrefabs defaultPrefabs = default;
        [SerializeField] private Transform parentContainer = default;

        private CheatsDefinitionBinder cheatsDefinitionBinder;

        private void Awake()
        {
            cheatsDefinitionBinder = new CheatsDefinitionBinder(
                JuceCheats.Instance.CheatsDefinition, 
                parentContainer,
                defaultPrefabs
                );

            cheatsDefinitionBinder.Bind();
        }

        private void OnDestroy()
        {
            cheatsDefinitionBinder.Unbind();
        }
    }
}
