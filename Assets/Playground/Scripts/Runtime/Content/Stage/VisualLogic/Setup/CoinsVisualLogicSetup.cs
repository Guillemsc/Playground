using Playground.Content.Stage.VisualLogic.Entities;

namespace Playground.Content.Stage.VisualLogic.Setup
{
    public class CoinsVisualLogicSetup
    {
        public float SpawnPercentageProbabiliby { get; }
        public CoinEntityView Prefab { get; }

        public CoinsVisualLogicSetup(
            float spawnPercentageProbabiliby,
            CoinEntityView prefab
            )
        {
            SpawnPercentageProbabiliby = spawnPercentageProbabiliby;
            Prefab = prefab;
        }
    }
}
