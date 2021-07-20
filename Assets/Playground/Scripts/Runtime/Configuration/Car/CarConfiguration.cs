using Playground.Content.Stage.VisualLogic.View.Car;
using UnityEngine;

namespace Playground.Configuration.Car
{
    [CreateAssetMenu(fileName = "CarConfiguration", menuName = "Playground/Configuration/CarConfiguration", order = 1)]
    public class CarConfiguration : ScriptableObject
    {
        [Header("Core")]
        [SerializeField] private string carTypeId = default;
        [SerializeField] private CarView carViewPrefab = default;

        [Header("Info")]
        [SerializeField] private string carName = default;
        [SerializeField] private string carDescription = default;
        [SerializeField] private Sprite carIcon = default;

        [Header("Shop")]
        [SerializeField] private int carShopPrice = default;

        public string CarTypeId => carTypeId;
        public CarView CarViewPrefab => carViewPrefab;
        public Sprite CarIcon => carIcon;
        public string CarName => carName;
        public string CarDescription => carDescription;
        public int CarShopPrice => carShopPrice;
    }
}
