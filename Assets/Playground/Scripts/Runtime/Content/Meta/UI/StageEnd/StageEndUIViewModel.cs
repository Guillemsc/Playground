using Juce.Core.Observables;
using UnityEngine.EventSystems;

namespace Playground.Content.Meta.UI.StageEnd
{
    public class StageEndUIViewModel
    {
        public ObservableEvent<StageEndUIView, PointerEventData> OnPlayAgainEvent { get; }
            = new ObservableEvent<StageEndUIView, PointerEventData>();

        public ObservableVariable<string> CurrentPointsVariable { get; }
            = new ObservableVariable<string>();

        public ObservableVariable<string> BestPointsVariable { get; }
            = new ObservableVariable<string>();
    }
}
