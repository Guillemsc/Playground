using Playground.Configuration.Car;
using System.Collections.Generic;
using UnityEngine;

namespace Playground.Libraries.Car
{
    [CreateAssetMenu(fileName = "CarLibrary", menuName = "Playground/Libraries/CarLibrary", order = 1)]
    public class CarLibrary : ScriptableObject
    {
        [SerializeField] private List<CarConfiguration> items = new List<CarConfiguration>();

        public IReadOnlyList<CarConfiguration> Items => items;

        public bool TryGet(string carTypeId, out CarConfiguration carConfiguration)
        {
            foreach(CarConfiguration item in items)
            {
                if(string.Equals(item.CarTypeId, carTypeId))
                {
                    carConfiguration = item;
                    return true;
                }
            }

            carConfiguration = null;
            return false;
        }
    }
}
