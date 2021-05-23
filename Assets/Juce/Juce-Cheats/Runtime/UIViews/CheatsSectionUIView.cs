using UnityEngine;

namespace Juce.Cheats.UIViews
{
    public class CheatsSectionUIView : MonoBehaviour
    {
        [SerializeField] private Transform contentParent = default;

        public Transform ContentParent => contentParent;
    }
}
