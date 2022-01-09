using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class SignUIWithUpdate : MonoBehaviour
    {
        public float maxImageWidth;
        public float minImageWidth;
        public float maxImageHeight;
        public float minImageHeight;
    
        public Image signImage;
        public Text signText;
        private float _currentImageHeight;
        private float _currentImageWidth;
        private ContentSizeFitter _contentSizeFitter;
    
        // Start is called before the first frame update
        private void Start()
        {
            _contentSizeFitter = signText.GetComponent<ContentSizeFitter>();
        }

        // Update is called once per frame
        void Update()
        {
            AdjustSignBoxUpdate();
        }
    
        private void AdjustSignBoxUpdate()
        {
            var sizeDelta = signText.rectTransform.sizeDelta;

            var rect = signImage.rectTransform.rect;
            _currentImageHeight = rect.height;
            _currentImageWidth = rect.width;

            if (sizeDelta.x == 0) return;
        
            // //图片宽度已达到最大值，则接下来增加高度
            if (_currentImageWidth >= maxImageWidth)
            {
                _contentSizeFitter.horizontalFit = ContentSizeFitter.FitMode.Unconstrained;
                _contentSizeFitter.verticalFit = ContentSizeFitter.FitMode.PreferredSize;
            }

            signImage.rectTransform.sizeDelta =
                new Vector2(_currentImageWidth + (sizeDelta.x + 50), _currentImageHeight + (sizeDelta.y + 67));
        }
    }
}
