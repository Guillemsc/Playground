using Juce.Core.Observables;
using UnityEngine.EventSystems;

namespace Playground.Content.Meta.UI.StageEnd
{
    public class StageEndUIViewModel
    {
        public ObservableEvent<StageEndUIView, PointerEventData> OnPlayAgainEvent { get; }
            = new ObservableEvent<StageEndUIView, PointerEventData>();
    }
}
