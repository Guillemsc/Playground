using System;
using System.Collections.Generic;
using SRDebugger.Internal;

namespace SRDebugger
{
    public delegate void OptionValueChangedHandler(OptionDefinition option);

    /// <summary>
    /// You can implement this interface to create a dynamic "options container".
    /// Add the container to SRDebugger via the SRDebug API.
    /// </summary>
    public interface IOptionContainer
    {
        /// <summary>
        /// Get the initial set of options contained in this object.
        /// </summary>
        IEnumerable<OptionDefinition> GetOptions();

        /// <summary>
        /// Will the options collection be changed?
        /// If true, the current set of options will be retrieved via <see cref="GetOptions"/> and subsequent changes
        /// will need to be provided via <see cref="OptionAdded"/> and <see cref="OptionRemoved"/>.
        /// </summary>
        bool IsDynamic { get; }

        event Action<OptionDefinition> OptionAdded;
        event Action<OptionDefinition> OptionRemoved;
    }

    public sealed class DynamicOptionContainer : IOptionContainer
    {
        public IList<OptionDefinition> Options
        {
            get { return _optionsReadOnly; }
        }

        private readonly List<OptionDefinition> _options = new List<OptionDefinition>();
        private readonly IList<OptionDefinition> _optionsReadOnly;

        public DynamicOptionContainer()
        {
            _optionsReadOnly = _options.AsReadOnly();
        }

        public void AddOption(OptionDefinition option)
        {
            _options.Add(option);

            if (OptionAdded != null)
            {
                OptionAdded(option);
            }
        }

        public bool RemoveOption(OptionDefinition option)
        {
            if (_options.Remove(option))
            {
                if (OptionRemoved != null)
                {
                    OptionRemoved(option);
                }

                return true;
            }

            return false;
        }
        
        IEnumerable<OptionDefinition> IOptionContainer.GetOptions()
        {
            return _options;
        }

        public bool IsDynamic
        {
            get { return true; }
        }

        public event Action<OptionDefinition> OptionAdded;
        public event Action<OptionDefinition> OptionRemoved;
    }

}