using Juce.Cheats.Definition;
using UnityEngine;

namespace Juce.Cheats.Binder
{
    public class CheatCollectionBinder
    {
        private readonly Transform parentContainer;

        public CheatCollectionDefinition CheatCollectionDefinition { get; }

        public CheatCollectionBinder(
            CheatCollectionDefinition cheatCollectionDefinition,
            Transform parentContainer
            )
        {
            CheatCollectionDefinition = cheatCollectionDefinition;
            this.parentContainer = parentContainer;
        }

        public void Bind()
        {
            foreach(ICheat cheat in CheatCollectionDefinition.Cheats)
            {
                cheat.Init(parentContainer);
            }

            CheatCollectionDefinition.OnCheatAdded += OnCheatAdded;
            CheatCollectionDefinition.OnCheatRemoved += OnCheatRemoved;
        }

        public void Unbind()
        {
            CheatCollectionDefinition.OnCheatAdded -= OnCheatAdded;
            CheatCollectionDefinition.OnCheatRemoved -= OnCheatRemoved;

            foreach (ICheat cheat in CheatCollectionDefinition.Cheats)
            {
                cheat.CleanUp();
            }
        }

        private void OnCheatAdded(ICheat cheat)
        {
            cheat.Init(parentContainer);
        }

        private void OnCheatRemoved(ICheat cheat)
        {
            cheat.CleanUp();
        }
    }
}
