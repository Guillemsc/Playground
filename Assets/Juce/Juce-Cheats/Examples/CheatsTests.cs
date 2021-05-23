using Juce.Cheats;
using Juce.Cheats.Definition;
using Juce.Cheats.UIViews;
using UnityEngine;

public class CheatsTests : MonoBehaviour
{
    [SerializeField] private ButtonCheatUIView buttonCheatUIView = default;

    CheatSectionDefinition cheatSectionDefinition3;
    CheatSectionDefinition cheatSectionDefinition;

    // Start is called before the first frame update
    void Start()
    {
        CheatCollectionDefinition cheatCollection = new CheatCollectionDefinition();
        cheatCollection.Add(new ButtonCheat(buttonCheatUIView));
        cheatCollection.Add(new ButtonCheat(buttonCheatUIView));
        cheatCollection.Add(new ButtonCheat(buttonCheatUIView));
        cheatCollection.Add(new ButtonCheat(buttonCheatUIView));

        CheatCollectionDefinition cheatCollection2 = new CheatCollectionDefinition();
        cheatCollection2.Add(new ButtonCheat(buttonCheatUIView));
        cheatCollection2.Add(new ButtonCheat(buttonCheatUIView));
        cheatCollection2.Add(new ButtonCheat(buttonCheatUIView));
        cheatCollection2.Add(new ButtonCheat(buttonCheatUIView));

        cheatSectionDefinition = new CheatSectionDefinition();
        cheatSectionDefinition.CheatsDefinition.AddCollection(new CheatCollectionDefinition());
        cheatSectionDefinition.CheatsDefinition.AddCollection(cheatCollection);

        cheatSectionDefinition3 = new CheatSectionDefinition();
        cheatSectionDefinition3.CheatsDefinition.AddCollection(new CheatCollectionDefinition());
        cheatSectionDefinition3.CheatsDefinition.AddCollection(cheatCollection2);
        cheatSectionDefinition3.CheatsDefinition.AddSection(cheatSectionDefinition);

        CheatSectionDefinition cheatSectionDefinition2 = new CheatSectionDefinition();
        cheatSectionDefinition2.CheatsDefinition.AddSection(cheatSectionDefinition3);

        JuceCheats.Instance.CheatsDefinition.AddSection(cheatSectionDefinition2);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("a"))
        {
            cheatSectionDefinition3.CheatsDefinition.RemoveSection(cheatSectionDefinition);

            //JuceCheats.Instance.CheatsDefinition.RemoveSection(cheatSectionDefinition);
        }
    }

    
}
