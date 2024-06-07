using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickedUpText : MonoBehaviour
{
    public GameObject invOB;
    public GameObject pickedUpText;
    private bool isFirstTime = true;


    void Start()
    {
        pickedUpText.SetActive(false);
        invOB.SetActive(false);
    }

    void Update()
    {
        if (invOB.activeInHierarchy && isFirstTime)
        {
            isFirstTime = false;
            StartCoroutine(ShowPickedUpText());
        }
        if (!invOB.activeInHierarchy && !isFirstTime)
        {
            pickedUpText.SetActive(false);
        }
    }

    IEnumerator ShowPickedUpText()
    {
        pickedUpText.SetActive(true);
        yield return new WaitForSeconds(3f);
        pickedUpText.SetActive(false);
    }
}
