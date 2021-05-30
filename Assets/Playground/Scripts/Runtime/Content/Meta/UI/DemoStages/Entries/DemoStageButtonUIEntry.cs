using Juce.Core.Events.Generic;
using Juce.CoreUnity.PointerCallback;
using Playground.Content.Stage.Configuration;
using System.IO;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Playground.Content.Stage.VisualLogic.UI.DemoStages
{
    public class DemoStageButtonUIEntry : MonoBehaviour
    {
        [SerializeField] private TMPro.TextMeshProUGUI stageNameText = default;
        [SerializeField] private PointerCallbacks pointerCallbacks = default;

        public StageConfiguration StageConfiguration { get; private set; }

        public event GenericEvent<DemoStageButtonUIEntry, PointerCallbacks> OnClicked;

        private void Awake()
        {
            pointerCallbacks.OnClick += OnPointerCallbacksClick;
        }

        private void OnDestroy()
        {
            pointerCallbacks.OnClick -= OnPointerCallbacksClick;
        }

        public void Init(StageConfiguration stageConfiguration)
        {
            StageConfiguration = stageConfiguration;

            string sceneName = Path.GetFileNameWithoutExtension(stageConfiguration.StageSceneReference.ScenePath);

            stageNameText.text = sceneName;
        }

        private void OnPointerCallbacksClick(PointerCallbacks pointerCallbacks, PointerEventData pointerEventData)
        {
            OnClicked?.Invoke(this, pointerCallbacks);
        }
    }
}
