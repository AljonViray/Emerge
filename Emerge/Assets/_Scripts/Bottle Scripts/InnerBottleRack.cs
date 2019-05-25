using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InnerBottleRack : MonoBehaviour
{
    public bool filled = false;
    private BottleRack bottleRack;
    private GameObject player;
    private GameObject playerHeldObject;



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

            player.GetComponent<PlayerInteraction>().releaseObj();
            playerHeldObject.transform.SetPositionAndRotation(this.transform.position, this.transform.rotation);
            playerHeldObject.GetComponent<Rigidbody>().isKinematic = true;
            filled = true;
            bottleRack.attempt.Add(playerHeldObject.name.Split('_')[0]);
            this.GetComponent<AudioSource>().Play();
        }
    }
}
