using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//<<<<<<< HEAD:Emerge/Assets/_Scripts/Dartboard Scripts/Dart.cs
//public class Dart : InteractableObject
//=======
public class Dart : InteractableObject
{
    public Vector3 originalPosition;
    public Quaternion originalRotation;


    void Start()
    {
        originalPosition = this.gameObject.transform.position;
        originalRotation = this.gameObject.transform.rotation;
    }
}
