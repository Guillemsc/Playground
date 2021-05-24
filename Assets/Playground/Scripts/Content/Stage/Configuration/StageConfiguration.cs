using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Playground.Content.Stage.Configuration
{
    [CreateAssetMenu(fileName = "StageConfiguration", menuName = "Playground/Configuration/StageConfiguration", order = 1)]
    public class StageConfiguration : ScriptableObject
    {
        [SerializeField] private AssetReference assetReference = default;

        public AssetReference AssetReference => assetReference;
    }
}
