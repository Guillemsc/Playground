using Playground.Content.StageUI.UI.ActionInputDetection;
using Playground.Content.StageUI.UI.DirectionSelector;
using Playground.Content.StageUI.UI.Effects;
using Playground.Content.StageUI.UI.Points;
using UnityEngine;

namespace Playground.Contexts.StageUI
{
    [System.Serializable]
    public class StageUIContextReferences
    {
        [Header("References")]
        [SerializeField] private ActionInputDetectionUIInstaller actionInputDetectionUIInstaller = default;
        [SerializeField] private DirectionSelectorUIInstaller directionSelectorUIInstaller = default;
        [SerializeField] private EffectsUIInstaller effectsUIInstaller = default;
        [SerializeField] private PointsUIInstaller pointsUIInstaller = default;

        public ActionInputDetectionUIInstaller ActionInputDetectionUIInstaller => actionInputDetectionUIInstaller;
        public DirectionSelectorUIInstaller DirectionSelectorUIInstaller => directionSelectorUIInstaller;
        public EffectsUIInstaller EffectsUIInstaller => effectsUIInstaller;
        public PointsUIInstaller PointsUIInstaller => pointsUIInstaller;
    }
}
