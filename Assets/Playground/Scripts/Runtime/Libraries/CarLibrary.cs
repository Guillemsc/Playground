using Playground.Configuration.Stage;
using System.Collections.Generic;
using UnityEngine;

namespace Playground.Libraries.Car
{
    [CreateAssetMenu(fileName = "CarLibrary", menuName = "Playground/Libraries/CarLibrary", order = 1)]
    public class CarLibrary : ScriptableObject
    {
        [SerializeField] private List<CarConfiguration> items = new List<CarConfiguration>();

        public IReadOnlyList<CarConfiguration> Items => items;
    }
}
