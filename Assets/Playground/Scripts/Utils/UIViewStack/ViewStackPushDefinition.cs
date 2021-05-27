using Playground.Utils.UI;
using System.Threading;
using System.Threading.Tasks;

namespace Playground.Utils.UIViewStack
{
    public class ViewStackPushDefinition
    {
        private readonly ViewContexRepository viewContexRepository;
        private readonly UIView uiView;

        private bool instantly;
        private bool asPopup;

        public ViewStackPushDefinition(
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

        public void AsPopup()
        {
            asPopup = true;
        }

        public Task Execute(CancellationToken cancellationToken)
        {
            if(asPopup)
            {
                ViewContex viewContext = viewContexRepository.Peek();

                if (viewContext == null)
                {
                    return Task.CompletedTask;
                }

                bool pupupAlreadyPushed = viewContext.PopupUIViews.Contains(uiView);

                if (pupupAlreadyPushed)
                {
                    return Task.CompletedTask;
                }

                viewContext.PopupUIViews.Add(uiView);

                return uiView.Show(instantly, cancellationToken); 
            }

            bool alreadyPushed = viewContexRepository.Contains(uiView);

            if (alreadyPushed)
            {
                return Task.CompletedTask;
            }

            viewContexRepository.Add(new ViewContex(uiView));

            return uiView.Show(instantly, cancellationToken);
        }
    }
}
