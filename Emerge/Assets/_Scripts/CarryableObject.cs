using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarryableObject : InteractableObject
{
    public override bool Interact(PlayerInteraction interactor)
    {
        interactor.PickupObj(this.gameObject);
        return true;
    }

    public virtual bool InteractWhileHeld(PlayerInteraction interactor)
    {
        Debug.Log(interactor.gameObject + " Is interacting with " + this.gameObject + " While holding it");
        return true;
    }
}
