using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//<<<<<<< HEAD:Emerge/Assets/_Scripts/Dartboard Scripts/Dart.cs
//public class Dart : InteractableObject
//=======
public class ResetObjects : CarryableObject
{

    void Start()
    {
        // If manually set the original, then do not get it's current
        if (originalPosition == Vector3.zero)
            originalPosition = this.transform.position;
        originalRotation = this.transform.rotation;
    }
}
