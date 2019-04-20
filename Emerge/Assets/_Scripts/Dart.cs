using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dart : CarryableObject
{
    public override bool Interact(PlayerInteraction interactor)
    {
        Debug.Log("Interact via DART");
        base.Interact(interactor);
        return true;

    }

    public override bool InteractWhileHeld(PlayerInteraction interactor)
    {
        Debug.Log("InteractWhileHeld via DART");
        interactor.releaseObj();
        return true;
    }
}
