using Juce.Core.Events.Generic;
using Juce.CoreUnity.Contracts;
using Juce.CoreUnity.PointerCallback;
using Playground.Configuration.Car;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Playground.Content.Meta.UI.CarsLibrary
{
    public class CarLibraryUIEntry : MonoBehaviour
    {
        [SerializeField] private TMPro.TextMeshProUGUI nameText = default;
        [SerializeField] private Image iconImage = default;
        [SerializeField] private PointerCallbacks pointerCallbacks = default;

        public event GenericEvent<CarLibraryUIEntry, PointerCallbacks> OnClicked;

        private void Awake()
        {
            Contract.IsNotNull(nameText, this);
            Contract.IsNotNull(iconImage, this);
            Contract.IsNotNull(pointerCallbacks, this);

            pointerCallbacks.OnClick += OnPointerCallbacksClick;
        }

        private void OnDestroy()
        {
            pointerCallbacks.OnClick -= OnPointerCallbacksClick;
        }

        public void Init(CarConfiguration carConfiguration)
        {
            nameText.text = carConfiguration.CarName;
            iconImage.sprite = carConfiguration.CarIcon;
        }

        private void OnPointerCallbacksClick(PointerCallbacks pointerCallbacks, PointerEventData pointerEventData)
        {
            OnClicked?.Invoke(this, pointerCallbacks);
        }
    }
}
