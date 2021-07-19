using Juce.Core.Events.Generic;
using Juce.CoreUnity.Contracts;
using Juce.CoreUnity.PointerCallback;
using Playground.Configuration.Car;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Playground.Content.Meta.UI.Shop
{
    public class ShopCarUIEntry : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private TMPro.TextMeshProUGUI nameText = default;
        [SerializeField] private TMPro.TextMeshProUGUI priceText = default;
        [SerializeField] private Image iconImage = default;
        [SerializeField] private PointerCallbacks pointerCallbacks = default;

        public event GenericEvent<ShopCarUIEntry, PointerCallbacks> OnClicked;

        private CarConfiguration carConfiguration;

        public string CarTypeId => carConfiguration.CarTypeId;

        private void Awake()
        {
            Contract.IsNotNull(nameText, this);
            Contract.IsNotNull(priceText, this);
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
            this.carConfiguration = carConfiguration;

            nameText.text = carConfiguration.CarName;
            priceText.text = carConfiguration.CarShopPrice.ToString();
            iconImage.sprite = carConfiguration.CarIcon;
        }

        private void OnPointerCallbacksClick(PointerCallbacks pointerCallbacks, PointerEventData pointerEventData)
        {
            OnClicked?.Invoke(this, pointerCallbacks);
        }
    }
}
