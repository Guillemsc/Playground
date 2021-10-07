using Playground.Content.StageUI.UI.ActionInputDetection;
using Playground.Content.StageUI.UI.DirectionSelector;
using UnityEngine;

namespace Playground.Contexts.StageUI
{
    [System.Serializable]
    public class StageUIContextReferences
    {
        [Header("References")]
        [SerializeField] private ActionInputDetectionUIInstaller actionInputDetectionUIInstaller = default;
        [SerializeField] private DirectionSelectorUIInstaller directionSelectorUIInstaller = default;

        public ActionInputDetectionUIInstaller ActionInputDetectionUIInstaller => actionInputDetectionUIInstaller;
        public DirectionSelectorUIInstaller DirectionSelectorUIInstaller => directionSelectorUIInstaller;
    }
}
