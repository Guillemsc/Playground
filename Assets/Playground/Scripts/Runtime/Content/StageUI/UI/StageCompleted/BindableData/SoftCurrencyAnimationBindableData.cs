using Juce.TweenPlayer.BindableData;
using UnityEngine;

namespace Playground.Content.StageUI.UI.StageCompleted
{
    [System.Serializable]
    [BindableData("Soft Currency Animation", "StageCompleted/SoftCurrencyAnimation", "f7112a9f-e05a-4007-a7d9-4c4299948623")]
    public class SoftCurrencyAnimationBindableData : IBindableData
    {
        [SerializeField] public int EndValue = default;
    }
}