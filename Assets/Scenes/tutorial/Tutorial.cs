using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{

    public UnityEngine.UI.Image image;
    public GameObject boxDialog;    
    public GameObject boxName;

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
        yield return new WaitForSeconds(0.3f);

        image.color = new Color(image.color.r, image.color.g, image.color.b, 1);
        while (image.color.a > 0.0f)
        {
            image.color = new Color(image.color.r, image.color.g, image.color.b, image.color.a - (Time.deltaTime / 2.0f));
            yield return null;
        }
        StartCoroutine(FadeTextToFullAlpha());
    }

    IEnumerator FadeTextToZero2()  // 알파값 1에서 0으로 전환

    {
        yield return new WaitForSeconds(0.3f);

        image.color = new Color(image.color.r, image.color.g, image.color.b, 1);
        while (image.color.a > 0.0f)
        {
            image.color = new Color(image.color.r, image.color.g, image.color.b, image.color.a - (Time.deltaTime / 2.0f));
            yield return null;
        }
        
        boxDialog.SetActive(true);
        boxName.SetActive(true);
        StopAllCoroutines();
    }

    IEnumerator FadeTextToFullAlpha() // 알파값 0에서 1로 전환
    {

        yield return new WaitForSeconds(0.3f);

        image.color = new Color(image.color.r, image.color.g, image.color.b, 0);
        while (image.color.a < 1.0f)
        {
            image.color = new Color(image.color.r, image.color.g, image.color.b, image.color.a + (Time.deltaTime / 2.0f));
            yield return null;
        }
        StartCoroutine(FadeTextToZero2());
    }
}
