using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    public GameObject WhiteLight;
    public AudioSource ClickOn;
    public AudioSource ClickOff;
    private bool lightActive = true;

    void Start()
    {
        WhiteLight.gameObject.SetActive(true);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (lightActive == true)
            {
                WhiteLight.gameObject.SetActive(false);
                lightActive = false;
                ClickOff.Play();
            }
            else
            {
                WhiteLight.gameObject.SetActive(true);
                lightActive = true;
                ClickOn.Play();
            }
        }
    }
}
