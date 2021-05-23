using UnityEngine;
using UnityEngine.UI;

namespace Juce.Cheats.UIViews
{
    public class ButtonCheatUIView : MonoBehaviour
    {
        [SerializeField] private Button button = default;

        public Button Button => button;
    }
}
