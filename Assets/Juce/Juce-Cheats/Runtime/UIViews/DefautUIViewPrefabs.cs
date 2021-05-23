using UnityEngine;

namespace Juce.Cheats.UIViews
{
    [System.Serializable]
    public class DefautUIViewPrefabs 
    {
        [SerializeField] private CheatsSectionUIView cheatsSectionUIViewPrefab = default;
        [SerializeField] private CheatsCollectionUIView cheatsCollectionUIViewPrefab = default;

        public CheatsSectionUIView CheatsSectionUIView => cheatsSectionUIViewPrefab;
        public CheatsCollectionUIView CheatsCollectionUIView => cheatsCollectionUIViewPrefab;
    }
}
