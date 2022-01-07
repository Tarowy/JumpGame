using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SignUI : MonoBehaviour
{
    public float maxImageWidth=500;
    public float minImageWidth=200;
    public float maxImageHeight=372;
    public float minImageHeight=100;
    
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
        AdjustSignBox();
    }
    
    private void AdjustSignBox()
    {
        if (_currentImageHeight >= maxImageHeight && _currentImageWidth >= maxImageWidth) return;

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
