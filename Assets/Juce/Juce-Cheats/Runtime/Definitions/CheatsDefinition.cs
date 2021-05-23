using System;
using System.Collections.Generic;

namespace Juce.Cheats.Definition
{
    public class CheatsDefinition
    {
        private readonly List<ICheatGroupDefinition> cheatGroupDefinitions = new List<ICheatGroupDefinition>();

        public IReadOnlyList<ICheatGroupDefinition> CheatGroupDefinitions => cheatGroupDefinitions;

        public event Action<CheatCollectionDefinition> OnCollectionAdded;
        public event Action<CheatCollectionDefinition> OnCollectionRemoved;

        public event Action<CheatSectionDefinition> OnSectionAdded;
        public event Action<CheatSectionDefinition> OnSectionRemoved;

        public void AddCollection(CheatCollectionDefinition collection)
        {
            cheatGroupDefinitions.Add(collection);

            OnCollectionAdded?.Invoke(collection);
        }

        public void RemoveCollection(CheatCollectionDefinition collection)
        {
            cheatGroupDefinitions.Remove(collection);

            OnCollectionRemoved?.Invoke(collection);
        }

        public void AddSection(CheatSectionDefinition section)
        {
            cheatGroupDefinitions.Add(section);

            OnSectionAdded?.Invoke(section);
        }

        public void RemoveSection(CheatSectionDefinition section)
        {
            cheatGroupDefinitions.Remove(section);

            OnSectionRemoved?.Invoke(section);
        }

        public void RemoveAll()
        {
            for(int i = cheatGroupDefinitions.Count - 1; i >= 0; --i)
            {
                ICheatGroupDefinition cheatGroupDefinition = cheatGroupDefinitions[i];

                switch(cheatGroupDefinition)
                {
                    case CheatCollectionDefinition collection:
                        {
                            RemoveCollection(collection);
                        }
                        break;

                    case CheatSectionDefinition section:
                        {
                            RemoveSection(section);
                        }
                        break;
                }
            }
        }
    }
}
