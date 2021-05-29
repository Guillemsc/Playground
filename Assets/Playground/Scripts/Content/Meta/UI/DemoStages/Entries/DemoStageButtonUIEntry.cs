using Juce.CoreUnity.PointerCallback;
using UnityEngine;

namespace Playground.Content.Stage.VisualLogic.UI.DemoStages
{
    public class DemoStageButtonUIEntry : MonoBehaviour
    {
        [SerializeField] private TMPro.TextMeshProUGUI stageNameText = default;
        [SerializeField] private PointerCallbacks pointerCallbacks = default;

        public PointerCallbacks PointerCallbacks => pointerCallbacks;

        public void Init(string stageName)
        {
            stageNameText.text = stageName;
        }
    }
}
