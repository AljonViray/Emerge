using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceholderPhoto : MonoBehaviour
{
    public GameObject player;


    private void Start()
    {
        player = GameObject.Find("Player");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Poster")
        {
            this.gameObject.GetComponent<AudioSource>().Play();
            player.GetComponent<PlayerInteraction>().ReleaseObj();
            Destroy(other.gameObject);
            GameObject alteredPhoto = GameObject.Find("AlteredPhoto");
            alteredPhoto.transform.GetChild(0).GetComponent<MeshRenderer>().enabled = true;
            for (int i = 1; i < alteredPhoto.transform.childCount; i++)
                alteredPhoto.transform.GetChild(i).GetComponent<SphereCollider>().enabled = true;
            this.gameObject.SetActive(false);
        }
    }
}
