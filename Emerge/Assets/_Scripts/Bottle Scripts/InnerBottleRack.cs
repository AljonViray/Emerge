using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InnerBottleRack : MonoBehaviour
{
    public bool filled = false;
    public Bottle.liquorType typeHeld;
    private BottleRack bottleRack;
    private GameObject player;
    private GameObject playerHeldObject;


    // Main Functions //
    private void Start()
    {
        player = GameObject.Find("Player");
        bottleRack = GameObject.Find("BottleRack").GetComponent<BottleRack>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.transform.parent.name == "---Bottles---" && filled == false)
        {
            playerHeldObject = player.GetComponent<PlayerInteraction>().heldObject;
            if (playerHeldObject == null) return;

            player.GetComponent<PlayerInteraction>().ReleaseObj();
            playerHeldObject.transform.SetPositionAndRotation(this.transform.position, this.transform.rotation);
            playerHeldObject.GetComponent<Rigidbody>().isKinematic = true;
            filled = true;
            typeHeld = playerHeldObject.GetComponent<Bottle>().myLiquorType;
            this.GetComponent<AudioSource>().Play();

            // add slot to attempt
            bottleRack.attempt.Add(playerHeldObject.GetComponent<Bottle>().myLiquorType);
            bottleRack.attemptSlots.Add(this.name);
        }
    }
}
