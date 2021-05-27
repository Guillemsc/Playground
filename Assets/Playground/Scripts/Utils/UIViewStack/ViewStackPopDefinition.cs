using Playground.Utils.UI;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Playground.Utils.UIViewStack
{
    public class ViewStackPopDefinition
    {
        private readonly ViewContexRepository viewContexRepository;
        private readonly UIView uiView;

        private bool instantly;

        public ViewStackPopDefinition(
            ViewContexRepository viewContexRepository,
            UIView uiView
            )
        {
            this.viewContexRepository = viewContexRepository;
            this.uiView = uiView;
        }

        public void Instantly()
        {
            instantly = true;
        }

        public async Task Execute(CancellationToken cancellationToken)
        {
            bool isPopup = IsPopup(out ViewContex foundPopupViewContext);

            if(isPopup)
            {
                foundPopupViewContext.PopupUIViews.Remove(uiView);

                await uiView.Hide(instantly, cancellationToken);

                return;
            }

            bool found = viewContexRepository.TryGet(uiView, out ViewContex foundViewContext);

            if(!found)
            {
                return; 
            }

            List<Task> popupsToHideTasks = new List<Task>();

            for(int i = 0; i < foundViewContext.PopupUIViews.Count; ++i)
            {
                UIView popupUiView = foundViewContext.PopupUIViews[i];

                popupsToHideTasks[i] = popupUiView.Hide(instantly, cancellationToken);
            }

            await Task.WhenAll(popupsToHideTasks);

            await foundViewContext.UIView.Hide(instantly, cancellationToken);
        }

        private bool IsPopup(out ViewContex foundViewContext)
        {
            foreach(ViewContex viewContext in viewContexRepository.Items)
            {
                if(viewContext.PopupUIViews.Contains(uiView))
                {
                    foundViewContext = viewContext;
                    return true;
                }
            }

            foundViewContext = null;
            return false;
        }
    }
}
