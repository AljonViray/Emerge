using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InnerBarrelRack : MonoBehaviour
{
    public GameObject newPosition_1;
    public GameObject newPosition_2;
    public bool bottomFilled = false;
    public bool allFilled = false;

    private BarrelRack barrelRack;
    private GameObject player;
    private GameObject playerHeldObject;



    private void Start()
    {
        player = GameObject.Find("Player");
        barrelRack = transform.parent.GetComponent<BarrelRack>();
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
                barrelRack.attempt.Add(newPosition_1.name);
            }
            else if (bottomFilled == true && allFilled == false)
            {
                playerHeldObject.transform.SetPositionAndRotation(newPosition_2.transform.position, newPosition_2.transform.rotation);
                playerHeldObject.GetComponent<Rigidbody>().isKinematic = true;
                allFilled = true;
                barrelRack.attempt.Add(newPosition_2.name);
            }
        }
    }
}
