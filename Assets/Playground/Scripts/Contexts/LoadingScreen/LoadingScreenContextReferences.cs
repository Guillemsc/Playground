using Cinemachine;
using Playground.Content.LoadingScreen.UI;
using Playground.Content.Stage.Libraries;
using UnityEngine;

namespace Playground.Contexts
{
    [System.Serializable]
    public class LoadingScreenContextReferences
    {
        [Header("References")]
        [SerializeField] private LoadingScreenUIView loadingScreenUIView = default;

        public LoadingScreenUIView LoadingScreenUIView => loadingScreenUIView;
    }
}
