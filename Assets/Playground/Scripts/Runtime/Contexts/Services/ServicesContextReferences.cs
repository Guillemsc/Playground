using Juce.CoreUnity.UI;
using UnityEngine;

namespace Playground.Contexts.Services
{
    [System.Serializable]
    public class ServicesContextReferences
    {
        [SerializeField] private Canvas uiFrameCanvas = default;

        public Canvas UIFrameCanvas => uiFrameCanvas;
    }
}
