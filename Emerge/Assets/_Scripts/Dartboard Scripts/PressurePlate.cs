using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public GameObject player;


    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GetComponent<AudioSource>().pitch = 0.9f;
            GetComponent<AudioSource>().Play();
            player.GetComponent<PlayerInteraction>().onPressurePlate = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GetComponent<AudioSource>().pitch = 0.5f;
            GetComponent<AudioSource>().Play();
            player.GetComponent<PlayerInteraction>().onPressurePlate = false;
            GameObject.Find("Dartboard").GetComponent<Dartboard>().Reset();
        }
    }
}
