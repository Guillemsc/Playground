using Juce.CoreUnity.UI;
using System.Collections.Generic;

namespace Playground.Services.ViewStack
{
    public class ViewContex
    {
        public UIView UIView { get; }
        public List<UIView> PopupUIViews { get; } = new List<UIView>();

        public ViewContex(UIView uiView)
        {
            this.UIView = uiView;
        }
    }
}
