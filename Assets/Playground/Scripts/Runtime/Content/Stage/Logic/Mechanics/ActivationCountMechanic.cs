using System;
using System.Collections.Generic;

namespace Playground.Content.Stage.Logic.Mechanics
{
    public class ActivationCountMechanic : IMechanic
    {
        private const string AnonimousActivationId = "Anonimous";

        private readonly List<string> activations = new List<string>();

        public bool Active => activations.Count > 0;

        public void Add()
        {
            activations.Add(AnonimousActivationId);
        }

        public void Remove()
        {
            activations.Remove(AnonimousActivationId);
        }

        public void AddUnique(string activationId)
        {
            bool alreadyAdded = HasUnique(activationId);

            if(alreadyAdded)
            {
                return;
            }

            activations.Add(activationId);
        }

        public void RemoveUnique(string activationId)
        {
            activations.Remove(activationId);
        }

        public bool HasUnique(string activationId)
        {
            return activations.Contains(activationId);
        }
    }
}
