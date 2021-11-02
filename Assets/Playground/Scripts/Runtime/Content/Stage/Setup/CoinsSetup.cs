using Playground.Content.Stage.VisualLogic.Entities;

namespace Playground.Content.Stage.Setup
{
    public class CoinsSetup
    {
        public float SpawnPercentageProbabiliby { get; }
        public CoinEntityView Prefab { get; }

        public CoinsSetup(
            float spawnPercentageProbabiliby,
            CoinEntityView prefab
            )
        {
            SpawnPercentageProbabiliby = spawnPercentageProbabiliby;
            Prefab = prefab;
        }
    }
}
