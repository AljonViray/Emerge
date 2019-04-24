using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inner_Dartboard : MonoBehaviour
{
    public string hit;

    private Dartboard dartboard;


    private void Start()
    {
        dartboard = transform.parent.GetComponent<Dartboard>();
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Interactable" 
            && collision.gameObject.name.Split('_')[0] == "Dart"
            && dartboard.attempt.Contains(collision.gameObject.name) == false)
        {
            Debug.Log(collision.gameObject.name + " stuck to " + this.gameObject.name);
            collision.rigidbody.isKinematic = true;
            dartboard.attempt.Add(this.gameObject.name);
        }
    }
}
