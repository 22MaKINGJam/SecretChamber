using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    // public static Background backgroundManager;

    public GameObject Broom, Blibrary, Bhallway;

    // Start is called before the first frame update
    void Awake()
    {
        
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetRoom()
    {
        Broom = GameObject.Find("Background").transform.Find("Broom").gameObject;
        Broom.SetActive(true);
        Blibrary = GameObject.Find("Background").transform.Find("Blibrary").gameObject;
        Blibrary.SetActive(false);
        Bhallway = GameObject.Find("Background").transform.Find("Bhallway").gameObject;
        Bhallway.SetActive(false);
    }

    public void SetLibrary()
    {
        Broom = GameObject.Find("Background").transform.Find("Broom").gameObject;
        Broom.SetActive(false);
        Blibrary = GameObject.Find("Background").transform.Find("Blibrary").gameObject;
        Blibrary.SetActive(true);
        Bhallway = GameObject.Find("Background").transform.Find("Bhallway").gameObject;
        Bhallway.SetActive(false);
    }

    public void SetHallway()
    {
        Broom = GameObject.Find("Background").transform.Find("Broom").gameObject;
        Broom.SetActive(false);
        Blibrary = GameObject.Find("Background").transform.Find("Blibrary").gameObject;
        Blibrary.SetActive(false);
        Bhallway = GameObject.Find("Background").transform.Find("Bhallway").gameObject;
        Bhallway.SetActive(true);
    }
}
