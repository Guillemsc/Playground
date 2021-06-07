using Playground.Content.Stage.VisualLogic.View.Car;
using UnityEngine;

namespace Playground.Configuration.Stage
{
    [CreateAssetMenu(fileName = "CarConfiguration", menuName = "Playground/Configuration/CarConfiguration", order = 1)]
    public class CarConfiguration : ScriptableObject
    {
        [SerializeField] private CarView carViewPrefab = default;

        public CarView CarViewPrefab => carViewPrefab;
    }
}
