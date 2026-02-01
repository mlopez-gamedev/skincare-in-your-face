using System.Collections.Generic;
using MiguelGameDev;

namespace Campero.SkincareInYourFace.Items
{
    public class ItemStates : SingletonBehaviour<ItemStates>
    {
        private List<ItemModel> _viewedItems = new List<ItemModel>();

        public ItemModel[] GetViewedItems()
        {
            return _viewedItems.ToArray();
        }

        public void ViewItem(ItemModel item)
        {
            if (_viewedItems.Contains(item))
            {
                return;
            }
            _viewedItems.Add(item);
        }

        public bool IsItemViewed(ItemModel item)
        {
            return _viewedItems.Contains(item);
        }
    }
}