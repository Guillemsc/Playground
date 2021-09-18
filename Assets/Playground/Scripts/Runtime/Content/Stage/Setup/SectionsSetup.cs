using Playground.Content.Stage.VisualLogic.Entities;
using System.Collections.Generic;

namespace Playground.Content.Stage.Setup
{
    public class SectionsSetup
    {
        public IReadOnlyList<SectionEntityView> Sections { get; }

        public SectionsSetup(
            IReadOnlyList<SectionEntityView> sections
            )
        {
            Sections = sections;
        }
    }
}
