﻿namespace Playground.Content.Meta.UI.MainMenu
{
    public class CarViewRotationData
    {
        public bool IsManuallyRotating { get; set; } = false;
        public float CurrentCarriedRotationSpeed { get; set; } = 0.0f;
        public float CurrentCarriedRotationDecelerationTime { get; set; } = 0.0f;
    }
}
