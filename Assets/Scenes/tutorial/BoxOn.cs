using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxOn : MonoBehaviour
{
    public GameObject boxDialog;    
    public GameObject boxName;

    public void Box_on()
    {
        boxDialog.SetActive(true);
        boxName.SetActive(true);
    }
}
