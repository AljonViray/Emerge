using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public GameObject dartboard;

    void Start()
    {
        dartboard = GameObject.Find("Dartboard");
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        GetComponent<AudioSource>().Play();
        if (other.tag == "Player")
        {
            //dartboard.GetComponent<Dartboard>().
        }
    }

    private void OnTriggerExit(Collider other)
    {
        
    }
}
