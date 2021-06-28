namespace Playground.Content.Stage.VisualLogic.View.Stage
{
    public class StageViewRepository 
    {
        public StageView Item { get; private set; }

        public void SetItem(StageView item)
        {
            Item = item;
        }

        public bool HasItem()
        {
            return Item != null;
        }
    }
}
