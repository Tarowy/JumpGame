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

            if (Camera.main is { })
                _signIns.transform.position =
                    Camera.main.WorldToScreenPoint(gameObject.transform.position) +
                    new Vector3(0, _signIns.GetComponent<RectTransform>().rect.height / 2 + 30, 0);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                _signIns = Instantiate(signPre, GameObject.Find("Canvas").transform);
                _signIns.transform.GetChild(0).GetComponent<Text>().text = signText;
            }
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
