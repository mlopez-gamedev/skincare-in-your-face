using MiguelGameDev;
using UnityEngine;

namespace Campero.SkincareInYourFace.Items
{
    public class ItemPreviews : SingletonBehaviour<ItemPreviews>
    {
        [SerializeField] private ItemPreviewCamera[] _previewCameraPool;

        public ItemPreviewCamera GetPreviewCamera(ItemModel item)
        {
            foreach (var previewCamera in _previewCameraPool)
            {
                if (previewCamera.IsEmpty)
                {
                    previewCamera.Init(item);
                    return previewCamera;
                }
            }
            
            throw new System.Exception("ItemPreviews not found");
        }
    }
}