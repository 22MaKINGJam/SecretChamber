using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUp : MonoBehaviour
{
    public Image popup_ask;
    public Image popup_pause;

    public void Ask()
    {

        popup_ask.gameObject.SetActive(true);
    }
    public void Adv()
    {

    }

    public void Rest()
    {
        popup_ask.gameObject.SetActive(false);

    }

    public void Pause()
    {
        popup_pause.gameObject.SetActive(true);
    }

    public void Back2Game()
    {
        popup_pause.gameObject.SetActive(false);
    }

    public void GoMain()
    {
        popup_pause.gameObject.SetActive(false);
    }
}