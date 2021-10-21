using Juce.CoreUnity.Factories;
using Playground.Content.StageUI.UI.ToasterTexts.Entries;
using UnityEngine;

namespace Playground.Content.StageUI.UI.ToasterTexts.Factories
{
    public class ToasterTextUIEntryFactory : MonoBehaviourKnownPrefabFactory<ToasterTextUIEntryFactoryDefinition, ToasterTextUIEntry>
    {
        public ToasterTextUIEntryFactory(ToasterTextUIEntry prefab, Transform parent) : base(prefab, parent)
        {

        }

        protected override void Init(ToasterTextUIEntryFactoryDefinition definition, ToasterTextUIEntry creation)
        {
            creation.Init(definition.Text);
        }
    }
}
