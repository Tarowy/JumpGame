using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class SignUIWithStart : MonoBehaviour
    {
        [Tooltip("背景的最小宽度")] public float minWidth;
        [Tooltip("背景的最大宽度")] public float maxWidth;
        [Tooltip("背景的最小高度")] public float minHeight;
        [Tooltip("背景的最大高度")] public float maxHeight;
    
        public Image signImage;
        private Text _verticalText;
        private Text _horizontalText;
        [HideInInspector]
        public string signText;
    
        // Start is called before the first frame update
        private void Start()
        {
            _verticalText = signImage.transform.GetChild(0).GetComponent<Text>();
            _horizontalText = signImage.transform.GetChild(1).GetComponent<Text>();
            _verticalText.text = _horizontalText.text = signText;
            StartCoroutine(AdjustSignBoxExecutor());
        }

        private void AdjustSignBoxSize()
        {
            var verticalTextSize = _verticalText.rectTransform.sizeDelta;
            var horizontalTextSize = _horizontalText.rectTransform.sizeDelta;

            if (horizontalTextSize.x > maxWidth - 50)
            {
                Destroy(_horizontalText.gameObject);
                _verticalText.gameObject.SetActive(true);

                signImage.rectTransform.sizeDelta = new Vector2(maxWidth, minHeight + 67 - verticalTextSize.y);
                return;
            }

            signImage.rectTransform.sizeDelta = new Vector2(horizontalTextSize.x + 50, minHeight);
            Destroy(_verticalText.gameObject);
        }

        private IEnumerator AdjustSignBoxExecutor()
        {
            yield return new WaitForEndOfFrame();
            AdjustSignBoxSize();
        }
    }
}
