using UnityEngine;

namespace Items
{
    public class Coin : MonoBehaviour
    {
        public AudioClip coinSound;
        
        private void Start()
        {
            Invoke("ChangeTag", 1f);
        }

        public void ChangeTag()
        {
            gameObject.tag = "Coin";
        }
    }
}
