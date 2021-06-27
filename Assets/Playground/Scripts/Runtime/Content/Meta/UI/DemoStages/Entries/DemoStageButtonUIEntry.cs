using Juce.Core.Events.Generic;
using Juce.CoreUnity.PointerCallback;
using Playground.Configuration.Stage;
using System.IO;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Playground.Content.Meta.UI.DemoStages
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

            stageNameText.text = stageConfiguration.StageName;
        }

        private void OnPointerCallbacksClick(PointerCallbacks pointerCallbacks, PointerEventData pointerEventData)
        {
            OnClicked?.Invoke(this, pointerCallbacks);
        }
    }
}
