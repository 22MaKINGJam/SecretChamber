using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeIn : MonoBehaviour
{

    public UnityEngine.UI.Image image;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FadeTextToZero());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator FadeTextToZero()  // 알파값 1에서 0으로 전환
       
    {

        yield return new WaitForSeconds(0.5f);

        image.color = new Color(image.color.r, image.color.g, image.color.b, 1);
        while (image.color.a > 0.0f)
        {
            image.color = new Color(image.color.r, image.color.g, image.color.b, image.color.a - (Time.deltaTime / 2.0f));
            yield return null;
        }
        //StartCoroutine(FadeTextToFullAlpha());
    }
}
