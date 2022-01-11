using UnityEngine;

namespace UI
{
    public class ImageChanger : MonoBehaviour
    {
        public Sprite[] sprites;
        public SpriteRenderer spriteRenderer;
        private Animator _animator;
        private int _index;

        private void Start()
        {
            _animator = GetComponent<Animator>();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                _animator.SetTrigger("change");
            }
        }

        public void ChangeImage()
        {
            _index = ++_index > sprites.Length - 1 ? 0 : _index;
            spriteRenderer.sprite = sprites[_index];
        }
    }
}
