using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InnerBarrelRack : MonoBehaviour
{
    public bool filled = false;
    private BarrelRack barrelRack;
    private GameObject player;
    private GameObject playerHeldObject;


    // Main Functions //
    private void Start()
    {
        player = GameObject.Find("Player");
        barrelRack = GameObject.Find("BarrelRack").GetComponent<BarrelRack>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Split('_')[0] == "Barrel")
        {
            playerHeldObject = player.GetComponent<PlayerInteraction>().heldObject;
            if (playerHeldObject == null) return;

            player.GetComponent<PlayerInteraction>().ReleaseObj();

            if (filled == false)
            {
                this.GetComponent<AudioSource>().Play();
                playerHeldObject.transform.SetPositionAndRotation(this.transform.position, this.transform.rotation);
                playerHeldObject.GetComponent<Rigidbody>().isKinematic = true;
                filled = true;
                barrelRack.attempt.Add(this.name);
            }
        }
    }
}
