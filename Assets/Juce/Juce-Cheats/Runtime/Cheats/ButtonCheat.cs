using Juce.Cheats.UIViews;
using UnityEngine;

namespace Juce.Cheats.Definition
{
    public class ButtonCheat : ICheat
    {
        private readonly ButtonCheatUIView buttonCheatPrefab;

        private ButtonCheatUIView buttonCheatUIView;

        public ButtonCheat(ButtonCheatUIView buttonCheat)
        {
            this.buttonCheatPrefab = buttonCheat;
        }

        public void Init(Transform container)
        {
            GameObject instance = MonoBehaviour.Instantiate(buttonCheatPrefab.gameObject, container);
            buttonCheatUIView = instance.GetComponent<ButtonCheatUIView>();
        }

        public void CleanUp()
        {
            MonoBehaviour.Destroy(buttonCheatUIView.gameObject);
        }
    }
}
