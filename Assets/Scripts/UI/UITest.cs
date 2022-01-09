using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITest : MonoBehaviour
{
    public Image signImage;
    public Text verticalText;
    public Text horizontalText;
    public string s;
    
    // Start is called before the first frame update
    void Start()
    {
        verticalText.text = horizontalText.text = s;
        StartCoroutine(AdjustExecute());
    }

    // Update is called once per frame
    void Update()   
    {
           
    }   
   
    public void Adjust()
    {
        var verticalTextSize = verticalText.rectTransform.sizeDelta;
        var horizontalTextSize = horizontalText.rectTransform.sizeDelta;

        Debug.Log("horizontalSize.x:" + horizontalTextSize.x);
        Debug.Log("verticalSize.x:" + verticalTextSize.y);

        if (horizontalTextSize.x > 450)
        {
            Destroy(horizontalText.gameObject);
            verticalText.gameObject.SetActive(true);

            signImage.rectTransform.sizeDelta = new Vector2(500, 100 + 67 - verticalTextSize.y);
            return;
        }

        signImage.rectTransform.sizeDelta = new Vector2(horizontalTextSize.x + 50, 100);
    }

    IEnumerator AdjustExecute()
    {
        yield return new WaitForEndOfFrame();
        Adjust();
    }
}
