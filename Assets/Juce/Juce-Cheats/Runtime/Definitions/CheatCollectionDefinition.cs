using System;
using System.Collections.Generic;

namespace Juce.Cheats.Definition
{
    public class CheatCollectionDefinition : ICheatGroupDefinition
    {
        private readonly List<ICheat> cheats = new List<ICheat>();

        public IReadOnlyList<ICheat> Cheats => cheats;

        public event Action<ICheat> OnCheatAdded;
        public event Action<ICheat> OnCheatRemoved;

        public void Add(ICheat cheat)
        {
            cheats.Add(cheat);

            OnCheatAdded?.Invoke(cheat);
        }

        public void Remove(ICheat cheat)
        {
            cheats.Remove(cheat);

            OnCheatRemoved?.Invoke(cheat);
        }
    }
}
