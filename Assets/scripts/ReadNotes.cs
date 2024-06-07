using System;
using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;


public class ReadNotes : MonoBehaviour
{
    public GameObject player;
    public GameObject noteUI;
    // public GameObject hud;
    public GameObject inv;

    public GameObject pickUpText;

    public AudioSource pickUpSound;

    public bool inReach;



    void Start()
    {
        noteUI.SetActive(false);
        // hud.SetActive(true);
        // inv.SetActive(true);
        pickUpText.SetActive(false);

        inReach = false;

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
        if (Input.GetButtonDown("Interact") && inReach)
        {
            noteUI.SetActive(true);
            pickUpSound.Play();
            // hud.SetActive(false);
            // inv.SetActive(false);
            // player.GetComponent<FirstPersonController>().enabled = false;
            DisableScriptsOnPlayer(new Type[] { typeof(FirstPersonMovement), typeof(Jump), typeof(Crouch) });
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }

    }


    public void ExitButton()
    {

        noteUI.SetActive(false);
        // hud.SetActive(true);
        // inv.SetActive(true);
        // player.GetComponent<FirstPersonController>().enabled = true;
        EnableScriptsOnPlayer(new Type[] { typeof(FirstPersonMovement), typeof(Jump), typeof(Crouch) });
        Cursor.visible = false;

    }

    private void DisableScriptsOnPlayer(Type[] scriptTypes)
    {
        foreach (Type scriptType in scriptTypes)
        {
            MonoBehaviour script = player.GetComponent(scriptType) as MonoBehaviour;
            if (script != null)
            {
                script.enabled = false;
            }
        }
    }

    private void EnableScriptsOnPlayer(Type[] scriptTypes)
    {
        foreach (Type scriptType in scriptTypes)
        {
            MonoBehaviour script = player.GetComponent(scriptType) as MonoBehaviour;
            if (script != null)
            {
                script.enabled = true;
            }
        }
    }
}
