using UnityEngine;

namespace Juce.Cheats.UIViews
{
    public class CheatsCollectionUIView : MonoBehaviour
    {
        [SerializeField] private Transform contentParent = default;

        public Transform ContentParent => contentParent;
    }
}
