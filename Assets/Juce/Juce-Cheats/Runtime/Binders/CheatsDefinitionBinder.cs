using Juce.Cheats.Definition;
using Juce.Cheats.UIViews;
using System.Collections.Generic;
using UnityEngine;

namespace Juce.Cheats.Binder
{
    public class CheatsDefinitionBinder
    {
        private readonly Transform parentContainer;
        private readonly DefautUIViewPrefabs defautUIViewPrefabs;

        private readonly Dictionary<CheatCollectionBinder, CheatsCollectionUIView> cheatCollectionBinders 
            = new Dictionary<CheatCollectionBinder, CheatsCollectionUIView>();

        private readonly Dictionary<CheatsDefinitionBinder, CheatsSectionUIView> cheatsDefinitionBinders 
            = new Dictionary<CheatsDefinitionBinder, CheatsSectionUIView>();

        public CheatsDefinition CheatsDefinition { get; }

        public CheatsDefinitionBinder(
            CheatsDefinition cheatsDefinition, 
            Transform parentContainer,
            DefautUIViewPrefabs defautUIViewPrefabs
            )
        {
            CheatsDefinition = cheatsDefinition;
            this.parentContainer = parentContainer;
            this.defautUIViewPrefabs = defautUIViewPrefabs;
        }

        public void Bind()
        {
            foreach (ICheatGroupDefinition cheatGroupDefinition in CheatsDefinition.CheatGroupDefinitions)
            {
                switch(cheatGroupDefinition)
                {
                    case CheatCollectionDefinition cheatCollectionDefinition:
                        {
                            AddCollection(cheatCollectionDefinition);
                        }
                        break;

                    case CheatSectionDefinition cheatSectionDefinition:
                        {
                            AddSection(cheatSectionDefinition);
                        }
                        break;

                    default:
                        {
                            throw new System.Exception();
                        }
                }
            }

            CheatsDefinition.OnCollectionAdded += OnCollectionAdded;
            CheatsDefinition.OnCollectionRemoved += OnCollectionRemoved;
            CheatsDefinition.OnSectionAdded += OnSectionAdded;
            CheatsDefinition.OnSectionRemoved += OnSectionRemoved;
        }

        public void Unbind()
        {
            CheatsDefinition.RemoveAll();

            CheatsDefinition.OnCollectionAdded -= OnCollectionAdded;
            CheatsDefinition.OnCollectionRemoved -= OnCollectionRemoved;
            CheatsDefinition.OnSectionAdded -= OnSectionAdded;
            CheatsDefinition.OnSectionRemoved -= OnSectionRemoved;
        }

        private void OnCollectionAdded(CheatCollectionDefinition cheatCollectionDefinition)
        {
            AddCollection(cheatCollectionDefinition);
        }

        private void OnCollectionRemoved(CheatCollectionDefinition cheatCollectionDefinition)
        {
            RemoveCollection(cheatCollectionDefinition);
        }

        private void OnSectionAdded(CheatSectionDefinition cheatSectionDefinition)
        {
            AddSection(cheatSectionDefinition);
        }

        private void OnSectionRemoved(CheatSectionDefinition cheatSectionDefinition)
        {
            RemoveSection(cheatSectionDefinition);
        }

        private void AddCollection(CheatCollectionDefinition cheatCollectionDefinition)
        {
            GameObject instance = MonoBehaviour.Instantiate(defautUIViewPrefabs.CheatsCollectionUIView.gameObject, parentContainer);
            CheatsCollectionUIView cheatsCollectionUIView = instance.GetComponent<CheatsCollectionUIView>();

            CheatCollectionBinder cheatCollectionBinder = new CheatCollectionBinder(
                cheatCollectionDefinition,
                cheatsCollectionUIView.ContentParent
                );

            cheatCollectionBinder.Bind();

            cheatCollectionBinders.Add(cheatCollectionBinder, cheatsCollectionUIView);
        }

        private void RemoveCollection(CheatCollectionDefinition cheatCollectionDefinition)
        {
            bool found = TryGetCheatCollectionBinder(
                cheatCollectionDefinition, 
                out CheatCollectionBinder cheatCollectionBinder,
                out CheatsCollectionUIView cheatsCollectionUIView
                );

            if (!found)
            {
                return;
            }

            cheatCollectionBinder.Unbind();

            cheatCollectionBinders.Remove(cheatCollectionBinder);

            MonoBehaviour.Destroy(cheatsCollectionUIView.gameObject);
        }

        private void AddSection(CheatSectionDefinition cheatSectionDefinition)
        {
            GameObject instance = MonoBehaviour.Instantiate(defautUIViewPrefabs.CheatsSectionUIView.gameObject, parentContainer);
            CheatsSectionUIView cheatsSectionUIView = instance.GetComponent<CheatsSectionUIView>();

            CheatsDefinitionBinder cheatsDefinitionBinder = new CheatsDefinitionBinder(
                cheatSectionDefinition.CheatsDefinition,
                cheatsSectionUIView.ContentParent,
                defautUIViewPrefabs
                );

            cheatsDefinitionBinder.Bind();

            cheatsDefinitionBinders.Add(cheatsDefinitionBinder, cheatsSectionUIView);
        }

        private void RemoveSection(CheatSectionDefinition cheatSectionDefinition)
        {
            bool found = TryGetCheatSectionBinder(
              cheatSectionDefinition.CheatsDefinition,
              out CheatsDefinitionBinder cheatsDefinitionBinder,
              out CheatsSectionUIView cheatsSectionUIView
              );

            if (!found)
            {
                return;
            }

            cheatsDefinitionBinder.Unbind();

            cheatsDefinitionBinders.Remove(cheatsDefinitionBinder);

            MonoBehaviour.Destroy(cheatsSectionUIView.gameObject);
        }

        private bool TryGetCheatCollectionBinder(
            CheatCollectionDefinition cheatCollectionDefinition, 
            out CheatCollectionBinder foundCheatCollectionBinder,
            out CheatsCollectionUIView foundCheatsCollectionUIView
            )
        {
            foreach(KeyValuePair< CheatCollectionBinder, CheatsCollectionUIView> cheatCollectionBinder in cheatCollectionBinders)
            {
                if(cheatCollectionBinder.Key.CheatCollectionDefinition == cheatCollectionDefinition)
                {
                    foundCheatCollectionBinder = cheatCollectionBinder.Key;
                    foundCheatsCollectionUIView = cheatCollectionBinder.Value;
                    return true;
                }
            }

            foundCheatCollectionBinder = null;
            foundCheatsCollectionUIView = null;
            return false;
        }

        private bool TryGetCheatSectionBinder(
          CheatsDefinition cheatsDefinition,
          out CheatsDefinitionBinder foundCheatCollectionBinder,
          out CheatsSectionUIView foundCheatsCollectionUIView
          )
        {
            foreach (KeyValuePair<CheatsDefinitionBinder, CheatsSectionUIView> cheatsDefinitionBinders in cheatsDefinitionBinders)
            {
                if (cheatsDefinitionBinders.Key.CheatsDefinition == cheatsDefinition)
                {
                    foundCheatCollectionBinder = cheatsDefinitionBinders.Key;
                    foundCheatsCollectionUIView = cheatsDefinitionBinders.Value;
                    return true;
                }
            }

            foundCheatCollectionBinder = null;
            foundCheatsCollectionUIView = null;
            return false;
        }
    }
}
