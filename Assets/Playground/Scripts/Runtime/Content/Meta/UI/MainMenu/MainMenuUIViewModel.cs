using Juce.Core.Observables;
using Juce.CoreUnity.DragPointerCallback;
using Juce.CoreUnity.PointerCallback;
using System;
using UnityEngine.EventSystems;

namespace Playground.Content.Meta.UI.MainMenu
{
    public class MainMenuUIViewModel 
    {
        public ObservableVariable<int> StarsVariable { get; }
            = new ObservableVariable<int>();
        public ObservableVariable<int> SoftCurrencyVariable { get; }
            = new ObservableVariable<int>();

        public ObservableEvent<DragPointerCallbacks, PointerEventData> OnStartDraggingCarViewEvent { get; } 
            = new ObservableEvent<DragPointerCallbacks, PointerEventData>();
        public ObservableEvent<DragPointerCallbacks, PointerEventData> OnStopDraggingCarViewEvent { get; } 
            = new ObservableEvent<DragPointerCallbacks, PointerEventData>();
        public ObservableEvent<DragPointerCallbacks, PointerEventData> OnDragCarViewEvent { get; } 
            = new ObservableEvent<DragPointerCallbacks, PointerEventData>();

        public ObservableEvent<PointerCallbacks, EventArgs> OnCarLibraryClickedEvent { get; } 
            = new ObservableEvent<PointerCallbacks, EventArgs>();
        public ObservableEvent<PointerCallbacks, EventArgs> OnDemoStagesClickedEvent { get; } 
            = new ObservableEvent<PointerCallbacks, EventArgs>();
        public ObservableEvent<PointerCallbacks, EventArgs> OnCreditsClickedEvent { get; } 
            = new ObservableEvent<PointerCallbacks, EventArgs>();

        public ObservableVariable<string> VersionValiable { get; } 
            = new ObservableVariable<string>();
    }
}
