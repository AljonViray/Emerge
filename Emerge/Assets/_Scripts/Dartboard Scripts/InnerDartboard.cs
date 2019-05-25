using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InnerDartboard : MonoBehaviour
{
    public AudioClip impactSound;
    private Dartboard dartboard;


    private void Start()
    {
        dartboard = transform.parent.GetComponent<Dartboard>();
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Split('_')[0] == "Dart")
        {
            collision.gameObject.GetComponent<AudioSource>().PlayOneShot(impactSound);
            Debug.Log(collision.gameObject.name + " stuck to " + this.gameObject.name);
            collision.rigidbody.isKinematic = true;
            if (!dartboard.attempt.Contains(this.gameObject.name)) dartboard.attempt.Add(this.gameObject.name);
        }
    }
}
