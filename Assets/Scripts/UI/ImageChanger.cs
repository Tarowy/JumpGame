using UnityEngine;

namespace UI
{
    public class ImageChanger : MonoBehaviour
    {
        public Sprite[] sprites;
        public SpriteRenderer spriteRenderer;
        private int _index;
    
        public void ChangeImage()
        {
            _index = ++_index > sprites.Length - 1 ? 0 : _index;
            spriteRenderer.sprite = sprites[_index];
        }
    }
}
