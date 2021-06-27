using Juce.Core.Events.Generic;
using Juce.CoreUnity.Contracts;
using Juce.CoreUnity.PointerCallback;
using Juce.TweenPlayer;
using Playground.Configuration.Car;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Playground.Content.Meta.UI.CarsLibrary
{
    public class CarLibraryUIEntry : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private TMPro.TextMeshProUGUI nameText = default;
        [SerializeField] private Image iconImage = default;
        [SerializeField] private PointerCallbacks pointerCallbacks = default;

        [Header("Feedbacks")]
        [SerializeField] private TweenPlayer showSelectedFeedback = default;
        [SerializeField] private TweenPlayer hideSelectedFeedback = default;

        public event GenericEvent<CarLibraryUIEntry, PointerCallbacks> OnClicked;

        private CarConfiguration carConfiguration;

        public string CarTypeId => carConfiguration.CarTypeId;

        private void Awake()
        {
            Contract.IsNotNull(nameText, this);
            Contract.IsNotNull(iconImage, this);
            Contract.IsNotNull(pointerCallbacks, this);

            Contract.IsNotNull(showSelectedFeedback, this);
            Contract.IsNotNull(hideSelectedFeedback, this);

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
            iconImage.sprite = carConfiguration.CarIcon;
        }

        public Task SetSelected(bool selected, bool instantly, CancellationToken cancellationToken)
        {
            if(selected)
            {
                hideSelectedFeedback.Kill();
                return showSelectedFeedback.Play(instantly, cancellationToken);
            }
            else
            {
                showSelectedFeedback.Kill();
                return hideSelectedFeedback.Play(instantly, cancellationToken);
            }
        }

        private void OnPointerCallbacksClick(PointerCallbacks pointerCallbacks, PointerEventData pointerEventData)
        {
            OnClicked?.Invoke(this, pointerCallbacks);
        }
    }
}
