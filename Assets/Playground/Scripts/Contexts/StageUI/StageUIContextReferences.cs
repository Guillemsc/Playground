using Playground.Content.StageUI.UI.StageCompleted;
using Playground.Content.StageUI.UI.StageOverlay;
using UnityEngine;

namespace Playground.Contexts
{
    [System.Serializable]
    public class StageUIContextReferences
    {
        [Header("References")]
        [SerializeField] private StageOverlayUIView stageOverlayUIView = default;
        [SerializeField] private StageCompletedUIView stageCompletedUIView = default;

        public StageOverlayUIView StageOverlayUIView => stageOverlayUIView;
        public StageCompletedUIView StageCompletedUIView => stageCompletedUIView;
    }
}
