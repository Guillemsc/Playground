using Playground.Content.Stage.VisualLogic.Cheats.UseCases.GetShipMaxSpeedCheat;
using Playground.Content.Stage.VisualLogic.Cheats.UseCases.SetShipSpeedCheat;
using SRDebugger;
using System.ComponentModel;
using UnityEngine;

namespace Playground.Content.Stage.VisualLogic.Cheats
{
    public class StageVisualLogicCheats
    {
        private readonly IGetShipMaxSpeedCheatUseCase getShipSpeedCheatUseCase;
        private readonly ISetShipSpeedCheatUseCase setShipSpeedCheatUseCase;

        public StageVisualLogicCheats(
            IGetShipMaxSpeedCheatUseCase getShipSpeedCheatUseCase,
            ISetShipSpeedCheatUseCase setShipSpeedCheatUseCase
            )
        {
            this.getShipSpeedCheatUseCase = getShipSpeedCheatUseCase;
            this.setShipSpeedCheatUseCase = setShipSpeedCheatUseCase;
        }

        [Category("Ship Stats Modifiers")]
        [NumberRange(0, 100)]
        public float ShipMaxSpeedModifier
        {
            get => getShipSpeedCheatUseCase.Execute();
            set => setShipSpeedCheatUseCase.Execute(value);
        }
    }
}
