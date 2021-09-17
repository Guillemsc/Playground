using Playground.Configuration.Stage;
using UnityEngine;

namespace Playground.Contexts.Services
{
    [System.Serializable]
    public class ServicesContextReferences
    {
        [SerializeField] private Canvas uiFrameCanvas = default;

        [Header("Configuration")]
        [SerializeField] private StageConfiguration stageConfiguration = default;

        public Canvas UIFrameCanvas => uiFrameCanvas;

        public StageConfiguration StageConfiguration => stageConfiguration;
    }
}
