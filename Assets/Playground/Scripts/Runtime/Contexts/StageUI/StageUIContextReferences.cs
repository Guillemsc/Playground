using Playground.Content.StageUI.UI.ActionInputDetection;
using Playground.Content.StageUI.UI.Coins;
using Playground.Content.StageUI.UI.DirectionSelector;
using Playground.Content.StageUI.UI.Effects;
using Playground.Content.StageUI.UI.MainStageUI;
using Playground.Content.StageUI.UI.Points;
using Playground.Content.StageUI.UI.ToasterTexts;
using UnityEngine;

namespace Playground.Contexts.StageUI
{
    [System.Serializable]
    public class StageUIContextReferences
    {
        [Header("References")]
        [SerializeField] private ActionInputDetectionUIInstaller actionInputDetectionUIInstaller = default;
        [SerializeField] private MainStageUIInstaller mainStageUIInstaller = default;
        [SerializeField] private DirectionSelectorUIInstaller directionSelectorUIInstaller = default;
        [SerializeField] private EffectsUIInstaller effectsUIInstaller = default;
        [SerializeField] private PointsUIInstaller pointsUIInstaller = default;
        [SerializeField] private CoinsUIInstaller coinsUIInstaller = default;
        [SerializeField] private ToasterTextsUIInstaller toasterTextsUIInstaller = default;

        public ActionInputDetectionUIInstaller ActionInputDetectionUIInstaller => actionInputDetectionUIInstaller;
        public MainStageUIInstaller MainStageUIInstaller => mainStageUIInstaller;
        public DirectionSelectorUIInstaller DirectionSelectorUIInstaller => directionSelectorUIInstaller;
        public EffectsUIInstaller EffectsUIInstaller => effectsUIInstaller;
        public PointsUIInstaller PointsUIInstaller => pointsUIInstaller;
        public CoinsUIInstaller CoinsUIInstaller => coinsUIInstaller;
        public ToasterTextsUIInstaller ToasterTextsUIInstaller => toasterTextsUIInstaller;
    }
}
