using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUp : MonoBehaviour
{
    public Image popup;
    public void Ask()
    {
        popup.gameObject.SetActive(true);
    }
    public void Adv()
    {

    }   
    
    public void Rest()
    {
        popup.gameObject.SetActive(false);
        
    }
}
