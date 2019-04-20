using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dartboard : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Interactable" && collision.gameObject.name.Split('_')[0] == "Dart")
        {
            Debug.Log("Dart stuck to " + this.gameObject.name);
            collision.rigidbody.isKinematic = true;
        }
    }
}
