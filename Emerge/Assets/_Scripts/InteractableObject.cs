using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual bool Interact(PlayerInteraction interactor)
    {
        Debug.Log(interactor.gameObject + " Is interacting with " + this.gameObject);
        return true;
    }
}
