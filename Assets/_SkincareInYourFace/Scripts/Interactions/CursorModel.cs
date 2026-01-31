using UnityEngine;

namespace Campero.SkincareInYourFace.Interactions
{
    [CreateAssetMenu(menuName = "Campero/Cursor")]
    public class CursorModel : ScriptableObject
    {
        [SerializeField] private Texture2D _texture;
        [SerializeField] private Vector2 _hotspot;
        
        public Texture2D Texture => _texture;
        public Vector2 Hotspot => _hotspot;
    }
}