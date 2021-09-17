using Playground.Content.StageUI.UI.ScreenCarControls;
using Playground.Content.StageUI.UI.StageCompleted;
using Playground.Content.StageUI.UI.StageOverlay;
using UnityEngine;

namespace Playground.Contexts.StageUI
{
    [System.Serializable]
    public class StageUIContextReferences
    {
        [Header("References")]
        [SerializeField] private ScreenCarControlsUIView screenCarControlsUIView = default;
        [SerializeField] private StageOverlayUIView stageOverlayUIView = default;
        [SerializeField] private StageCompletedUIView stageCompletedUIView = default;

        public ScreenCarControlsUIView ScreenCarControlsUIView => screenCarControlsUIView;
        public StageOverlayUIView StageOverlayUIView => stageOverlayUIView;
        public StageCompletedUIView StageCompletedUIView => stageCompletedUIView;
    }
}
