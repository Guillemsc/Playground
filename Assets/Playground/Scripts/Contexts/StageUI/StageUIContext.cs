using Juce.Core.Events;
using Juce.CoreUnity.Contexts;
using Juce.CoreUnity.Service;
using Juce.CoreUnity.Services;
using Playground.Content.LoadingScreen.UI;
using Playground.Content.Stage.Configuration;
using Playground.Content.Stage.Logic.CheckPoints;
using Playground.Content.Stage.Logic.EntryPoint;
using Playground.Content.Stage.Setup;
using Playground.Content.Stage.VisualLogic.EntryPoint;
using Playground.Content.Stage.VisualLogic.View.Stage;
using Playground.Services;
using Playground.Utils.Addressable;
using System.Threading.Tasks;
using UnityEngine;

namespace Playground.Contexts
{
    public class StageUIContext : Context
    {
        public readonly static string SceneName = "StageUIContext";

        [SerializeField] private StageUIContextReferences stageUIContextReferences;

        public StageUIContextReferences StageUIContextReferences => stageUIContextReferences;

        protected override void Init()
        {
            ContextsProvider.Register(this);
        }

        protected override void CleanUp()
        {
            ContextsProvider.Unregister(this);
        }
    }
}
