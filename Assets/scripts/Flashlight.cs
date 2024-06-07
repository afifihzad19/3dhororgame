using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    public GameObject flashlight;
    public GameObject flashlightBody;

    public AudioSource turnOn;
    public AudioSource turnOff;

    public bool on;
    public bool off;

    public bool obtained;


    void Start()
    {
        obtained = false;
        off = true;
        flashlightBody.SetActive(false);
        flashlight.SetActive(false);
    }




    void Update()
    {
        if (flashlightBody.activeInHierarchy)
        {
            obtained = true;
        }
        if (obtained && off && Input.GetButtonDown("Flashlight"))
        {
            flashlight.SetActive(true);
            turnOn.Play();
            off = false;
            on = true;
        }
        else if (obtained && on && Input.GetButtonDown("Flashlight"))
        {
            flashlight.SetActive(false);
            turnOff.Play();
            off = true;
            on = false;
        }



    }
}
