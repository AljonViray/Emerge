using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public virtual bool Interact(PlayerInteraction interactor)
    {
        Debug.Log(interactor.gameObject + " Is interacting with " + this.gameObject);
        return true;
    }
}
