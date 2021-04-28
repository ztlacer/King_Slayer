using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemText : MonoBehaviour
{

    private GameObject triggeringNPC;
    private bool triggering;

    public GameObject npcText;


    // Update is called once per frame
    void Update()
    {

        if (triggering)
        {
            print("fine");
            npcText.SetActive(true);

            if (InputManager.Controls.Player.OpenShop.triggered)
            {

                triggering = false;

            }
        }
        else
        {
            npcText.SetActive(false);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            triggering = true;
            triggeringNPC = other.gameObject;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            triggering = false;
            triggeringNPC = null;
        }
    }


}