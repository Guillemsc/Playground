using Playground.Content.LoadingScreen.UI;
using UnityEngine;

namespace Playground.Contexts.LoadingScreen
{
    public class LoadingScreenContextInstance : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private LoadingScreenUIView loadingScreenUIView = default;

        public LoadingScreenUIView LoadingScreenUIView => loadingScreenUIView;
    }
}
