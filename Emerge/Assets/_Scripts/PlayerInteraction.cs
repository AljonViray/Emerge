using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public GameObject held_object;
    public FixedJoint holding_point;
    float throw_force = 10;

    [Header("Private")]
    [SerializeField]
    private Camera _camera;


    void Update()
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
            if (held_object == null && Input.GetKeyDown(KeyCode.E))
            {
                pickupObj(lookingAt());
            }

            //Drop held object
            else if (held_object != null && Input.GetKeyDown(KeyCode.E))
            {
                releaseObj();
            }

            //Throw held object
            else if (held_object != null && Input.GetKeyDown(KeyCode.Mouse0))
            {
                throwObj();
            }
        }

        //Drop held object (not looking at it)
        else if (held_object != null && Input.GetKeyDown(KeyCode.E))
        {
            releaseObj();
        }

        //Throw held object (not looking at it)
        else if (held_object != null && Input.GetKeyDown(KeyCode.Mouse0))
        {
            throwObj();
        }
    }

    private GameObject lookingAt()
    {
        if (Physics.Raycast(_camera.transform.position, _camera.transform.forward, out RaycastHit hit, 3))
        {
            Debug.DrawRay(_camera.transform.position, _camera.transform.forward * hit.distance, Color.yellow);

            if (hit.transform.gameObject.tag == "Interactable") return hit.transform.gameObject;
            else return null;
        }
        else return null;
    }

    public void pickupObj(GameObject objToPickup)
    {
        held_object = objToPickup;

        holding_point = this.gameObject.AddComponent<FixedJoint>();
        holding_point.breakForce = 100;
        holding_point.connectedBody = held_object.GetComponent<Rigidbody>();

        held_object.transform.SetParent(_camera.transform);
    }

    private void OnJointBreak(float breakForce)
    {
        Destroy(holding_point);
        releaseObj();
    }

    public void releaseObj()
    {
        Destroy(holding_point);
        held_object.transform.SetParent(null);
        held_object = null;
    }

    public void throwObj()
    {
        Destroy(holding_point);
        held_object.transform.SetParent(null);
        held_object.GetComponent<Rigidbody>().AddForce(this.gameObject.transform.forward * throw_force);
        held_object = null;
    }
}
