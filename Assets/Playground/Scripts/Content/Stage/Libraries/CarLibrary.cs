using Playground.Content.Stage.VisualLogic.View.Car;
using UnityEngine;

namespace Playground.Content.Stage.Libraries
{
    [CreateAssetMenu(fileName = "CarLibrary", menuName = "Playground/Libraries/CarLibrary", order = 1)]
    public class CarLibrary : ScriptableObject
    {
        [SerializeField] private CarView defaultCarPrefab = default;

        public CarView DefaultCarPrefab => defaultCarPrefab;
    }
}
