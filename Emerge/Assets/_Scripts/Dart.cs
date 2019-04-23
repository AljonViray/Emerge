using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dart : MonoBehaviour
{
    public Vector3 originalPosition;
    public Quaternion originalRotation;


    void Start()
    {
        originalPosition = this.gameObject.transform.position;
        originalRotation = this.gameObject.transform.rotation;
    }
}
