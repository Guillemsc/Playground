﻿using Playground.Content.Stage.Logic.Entities;
using Playground.Content.Stage.Logic.Setup;

namespace Playground.Content.Stage.Logic.UseCases.TryCreateShip
{
    public interface ITryCreateShipUseCase
    {
        bool Execute(LogicShipSetup setup, out ShipEntity shipEntity);
    }
}
