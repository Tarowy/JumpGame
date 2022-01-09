using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class Sign : MonoBehaviour
    {
        public GameObject signPre;
        public string signText;

        private GameObject _signIns;

        private void Update()
        {
            if (_signIns == null) return;
            //文本框跟随
            if (Camera.main is { })
                _signIns.transform.position =
                    Camera.main.WorldToScreenPoint(gameObject.transform.position) +
                    new Vector3(0, _signIns.GetComponent<RectTransform>().rect.height / 2 + 30, 0);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag("Player")) return;
            _signIns = Instantiate(signPre, GameObject.Find("Canvas").transform);
            _signIns.GetComponent<SignUIWithStart>().signText = signText;
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                Destroy(_signIns);
            }
        }
    }
}
