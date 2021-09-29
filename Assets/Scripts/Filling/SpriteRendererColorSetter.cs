using UnityEngine;

namespace Galcon.Filling
{
    public class SpriteRendererColorSetter : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;


        public void SetColor(Color color)
        {
            _spriteRenderer.color = color;
        }
    }
}
