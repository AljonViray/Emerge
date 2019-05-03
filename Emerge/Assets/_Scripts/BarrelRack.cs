using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelRack : MonoBehaviour
{
    public GameObject newPosition_1;
    public GameObject newPosition_2;

    private GameObject player;
    private GameObject playerHeldObject;
    private bool bottomFilled = false;
    private bool allFilled = false;


    // Main Functions //

    private void Start()
    {
        player = GameObject.Find("Player");
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Split('_')[0] == "Barrel")
        {
            playerHeldObject = player.GetComponent<PlayerInteraction>().heldObject;
            if (playerHeldObject == null) return;

            player.GetComponent<PlayerInteraction>().releaseObj();

            if (bottomFilled == false && allFilled == false)
            {
                playerHeldObject.transform.SetPositionAndRotation(newPosition_1.transform.position, newPosition_1.transform.rotation);
                playerHeldObject.GetComponent<Rigidbody>().isKinematic = true;
                bottomFilled = true;
            }
            else if (bottomFilled == true && allFilled == false)
            {
                playerHeldObject.transform.SetPositionAndRotation(newPosition_2.transform.position, newPosition_2.transform.rotation);
                playerHeldObject.GetComponent<Rigidbody>().isKinematic = true;
                allFilled = true;
            }
        }
    }


    // Helper Functions //


}