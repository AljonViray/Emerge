using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteBoard : MonoBehaviour
{
    public GameObject[] anchors;


    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("NoteFragment"))
        {
            this.GetComponent<AudioSource>().Play();
            other.gameObject.transform.parent.gameObject.tag = "Untagged";
            other.gameObject.tag = "Untagged";
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInteraction>().releaseObj();
            other.transform.parent.gameObject.transform.parent
                = anchors[other.gameObject.GetComponentInParent<NoteFragment>().orderInReceipe].transform;
            other.gameObject.transform.parent.transform.localPosition = Vector3.zero;
            other.gameObject.transform.parent.transform.localRotation = Quaternion.Euler(new Vector3(0,90,0));
            other.gameObject.transform.parent.gameObject.GetComponent<Rigidbody>().isKinematic = true;
        }
    }
}
