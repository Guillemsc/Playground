﻿using Playground.Content.Stage.VisualLogic.Entities;
using System.Collections.Generic;

namespace Playground.Content.Stage.Setup
{
    public class SectionsSetup
    {
        public float DistanceBetweenSections { get; }
        public IReadOnlyList<SectionEntityView> Sections { get; }

        public SectionsSetup(
            float distanceBetweenSections,
            IReadOnlyList<SectionEntityView> sections
            )
        {
            DistanceBetweenSections = distanceBetweenSections;
            Sections = sections;
        }
    }
}
