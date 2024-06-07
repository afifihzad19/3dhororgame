using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickupflashlight : MonoBehaviour
{
    public GameObject FLObject;
    public GameObject invOB;
    public GameObject pickUpText;
    public AudioSource pickup;

    public bool inReach;


    void Start()
    {
        inReach = false;
        pickUpText.SetActive(false);
        invOB.SetActive(false);
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = true;
            pickUpText.SetActive(true);

        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = false;
            pickUpText.SetActive(false);

        }
    }


    void Update()
    {
        if (inReach && Input.GetButtonDown("Interact"))
        {
            FLObject.SetActive(false);
            pickup.Play();
            invOB.SetActive(true);
            pickUpText.SetActive(false);
        }

        
    }
}