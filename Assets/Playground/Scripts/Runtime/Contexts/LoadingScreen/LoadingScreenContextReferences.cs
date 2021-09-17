using Playground.Content.LoadingScreen.UI;
using UnityEngine;

namespace Playground.Contexts.LoadingScreen
{
    [System.Serializable]
    public class LoadingScreenContextReferences
    {
        [Header("References")]
        [SerializeField] private LoadingScreenUIView loadingScreenUIView = default;

        public LoadingScreenUIView LoadingScreenUIView => loadingScreenUIView;
    }
}
