using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InnerDartboard : MonoBehaviour
{
    public AudioClip impactSound;
    private Dartboard dartboard;


    private void Start()
    {
        dartboard = this.transform.parent.GetComponent<Dartboard>();
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Split('_')[0] == "Dart")
        {
            collision.gameObject.GetComponent<AudioSource>().PlayOneShot(impactSound, 1.5f);
            Debug.Log(collision.gameObject.name + " stuck to " + this.name);
            collision.rigidbody.isKinematic = true;
            if (!dartboard.attempt.Contains(this.name)) dartboard.attempt.Add(this.name);
        }
    }
}
