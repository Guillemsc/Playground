using Playground.Content.StageUI.UI.ActionInputDetection;
using UnityEngine;

namespace Playground.Contexts.StageUI
{
    [System.Serializable]
    public class StageUIContextReferences
    {
        [Header("References")]
        [SerializeField] private ActionInputDetectionUIView actionInputDetectionUIView = default;

        public ActionInputDetectionUIView ActionInputDetectionUIView => actionInputDetectionUIView;
    }
}
