using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteraction : MonoBehaviour
{
    public GameObject heldObject;
    public SpringJoint holdingPoint;
    public Text text;
    public float throwForce = 100;

    [Header("Private")]
    [SerializeField] private Camera _camera;


    // Main Functions //


    private void Update()
    {   /*
        if (LookingAt() && Input.GetKeyDown(KeyCode.E))
        {
            if (currentlyHeldObject != null)    // If holding something
            {
                currentlyHeldObject.SendMessage("InteractWhileHeld", this.GetComponent<PlayerInteraction>());
                currentlyHeldObject.transform.SetParent(this.gameObject.transform);
            }

            else if (currentlyHeldObject == null)   // If not holding something
            { 
                currentyEyelineTarget.SendMessage("Pick Up", this.GetComponent<PlayerInteraction>(),SendMessageOptions.DontRequireReceiver);
            }
        }
        */

        if (lookingAt() != null)
        {
            //Pick up object
            if (heldObject == null && Input.GetKeyDown(KeyCode.E))
            {
                pickupObj(lookingAt());
            }

            //Drop held object
            else if (heldObject != null && Input.GetKeyDown(KeyCode.E))
            {
                releaseObj();
            }

            //Throw held object
            else if (heldObject != null && Input.GetKeyDown(KeyCode.Mouse0))
            {
                throwObj();
            }
        }

        //Drop held object (not looking at it)
        else if (heldObject != null && Input.GetKeyDown(KeyCode.E))
        {
            releaseObj();
        }

        //Throw held object (not looking at it)
        else if (heldObject != null && Input.GetKeyDown(KeyCode.Mouse0))
        {
            throwObj();
        }
    }


    // Public Functions //


    public void pickupObj(GameObject objToPickup)
    {
        heldObject = objToPickup;

        holdingPoint = this.gameObject.AddComponent<SpringJoint>();
        holdingPoint.spring = 0.1f;
        holdingPoint.breakForce = 100;
        holdingPoint.breakTorque = 100;
        holdingPoint.tolerance = 0;

        holdingPoint.connectedBody = heldObject.GetComponent<Rigidbody>();
        heldObject.transform.SetParent(_camera.transform);
        heldObject.GetComponent<Rigidbody>().useGravity = false;
    }

    public void releaseObj()
    {
        Destroy(holdingPoint);
        heldObject.GetComponent<Rigidbody>().useGravity = true;
        heldObject.transform.SetParent(null);
        heldObject = null;
    }

    public void throwObj()
    {
        Destroy(holdingPoint);
        heldObject.GetComponent<Rigidbody>().useGravity = true;
        heldObject.transform.SetParent(null);
        heldObject.GetComponent<Rigidbody>().AddForce(this.gameObject.transform.forward * throwForce);
        heldObject = null;
    }


    // Private Functions //


    private GameObject lookingAt()
    {
        Ray ray = new Ray(_camera.transform.position, _camera.transform.forward);
        if (Physics.Raycast(ray, out RaycastHit hit, 3) && hit.transform.gameObject.tag == "Interactable")
        {
            Debug.DrawRay(_camera.transform.position, _camera.transform.forward * hit.distance, Color.yellow);
            if (heldObject == null) text.color = Color.green;
            else text.color = Color.white;
            return hit.transform.gameObject;
        }
        else
        {
            text.color = Color.black;
            return null;
        }
    }

    private void OnJointBreak(float breakForce)
    {
        Destroy(holdingPoint);
        releaseObj();
    }
}
