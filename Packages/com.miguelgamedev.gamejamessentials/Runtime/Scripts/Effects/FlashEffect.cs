using DG.Tweening;
using UnityEngine;

namespace MiguelGameDev
{
    public class FlashEffect : MonoBehaviour
    {
        [SerializeField]
        protected SpriteRenderer[] _renderers;

        public void Flash()
        {
            for (int i = 0; i < _renderers.Length; ++i)
            {
                _renderers[i].material.DOFloat(1f, "_FlashAmount", 0.1f).SetEase(Ease.OutFlash).SetLoops(2, LoopType.Yoyo);
            }
        }
    }
}