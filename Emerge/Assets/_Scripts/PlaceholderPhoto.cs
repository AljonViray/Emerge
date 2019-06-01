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
            other.gameObject.GetComponent<AudioSource>().Play();
            player.GetComponent<PlayerInteraction>().ReleaseObj();
            Destroy(other.gameObject);
            GameObject fakePhoto = GameObject.Find("FakePhoto");
            fakePhoto.GetComponent<MeshRenderer>().enabled = true;
            foreach (Transform child in fakePhoto.transform)
                child.GetComponent<SphereCollider>().enabled = true;
            this.gameObject.SetActive(false);
        }
    }
}
