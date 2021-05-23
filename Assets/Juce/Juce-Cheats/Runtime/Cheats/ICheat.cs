using UnityEngine;

namespace Juce.Cheats.Definition
{
    public interface ICheat
    {
        void Init(Transform container);
        void CleanUp();
    }
}
