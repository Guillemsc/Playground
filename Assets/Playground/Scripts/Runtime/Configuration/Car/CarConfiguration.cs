using Playground.Content.Stage.VisualLogic.View.Car;
using UnityEngine;

namespace Playground.Configuration.Car
{
    [CreateAssetMenu(fileName = "CarConfiguration", menuName = "Playground/Configuration/CarConfiguration", order = 1)]
    public class CarConfiguration : ScriptableObject
    {
        [SerializeField] private string carName = default;
        [SerializeField] private Sprite carIcon = default;
        [SerializeField] private CarView carViewPrefab = default;

        public Sprite CarIcon => carIcon;
        public string CarName => carName;
        public CarView CarViewPrefab => carViewPrefab;
    }
}
