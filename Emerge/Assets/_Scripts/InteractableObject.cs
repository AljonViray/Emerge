using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public Vector3 originalPosition;
    public Quaternion originalRotation;
    public bool interactable;

    protected void Start()
    {
        originalRotation = this.transform.localRotation;
        Debug.Log("Inter Obj Start " + this.gameObject);
    }

    public virtual bool Interact(PlayerInteraction interactor)
    {
        Debug.Log(interactor.gameObject + " Is interacting with " + this.gameObject);
        return true;
    }
}
