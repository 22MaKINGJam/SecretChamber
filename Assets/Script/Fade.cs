using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Fade : MonoBehaviour
{

    public UnityEngine.UI.Image image;

    public void FadeButton()
    {
        StartCoroutine(FadeTextToFullAlpha());

        Invoke("SceneChange", 2.0f);
    }

    public void SceneChange()
    {
        SceneManager.LoadScene("MyRoom");
    }

    public IEnumerator FadeTextToFullAlpha() // 알파값 0에서 1로 전환
    {
        image.color = new Color(image.color.r, image.color.g, image.color.b, 0);
        while (image.color.a < 1.0f)
        {
            image.color = new Color(image.color.r, image.color.g, image.color.b, image.color.a + (Time.deltaTime / 2.0f));
            yield return null;
        }
    }

    public IEnumerator FadeTextToZero()  // 알파값 1에서 0으로 전환
    {
        image.color = new Color(image.color.r, image.color.g, image.color.b, 1);
        while (image.color.a > 0.0f)
        {
            image.color = new Color(image.color.r, image.color.g, image.color.b, image.color.a - (Time.deltaTime / 2.0f));
            yield return null;
        }
        //StartCoroutine(FadeTextToFullAlpha());
    }

}
