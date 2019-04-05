using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public GameObject currentyEyelineTarget;
    public GameObject currentlyHeldObject;
    public FixedJoint holdingPoint;

    [Header("Private")]
    [SerializeField]
    private Rigidbody emptyRB;
    [SerializeField]
    private Camera _camera;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (LookingAt())
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (currentlyHeldObject != null)
                {
                    currentlyHeldObject.SendMessage("InteractWhileHeld", this.GetComponent<PlayerInteraction>());
                }
                else
                { 
                    currentyEyelineTarget.SendMessage("Interact", this.GetComponent<PlayerInteraction>(),SendMessageOptions.DontRequireReceiver);
  
                }
            }
        }
    }

    private bool LookingAt()
    {
        if (Physics.Raycast(_camera.transform.position, _camera.transform.forward, out RaycastHit hit))
        {
            Debug.DrawRay(_camera.transform.position, _camera.transform.forward * hit.distance, Color.yellow);
            currentyEyelineTarget = hit.transform.gameObject;
            return true;
        }
        else
        {
            return false;
        }
    }

    public void PickupObj(GameObject objToPickup)
    {
        currentlyHeldObject = objToPickup;
        holdingPoint = this.gameObject.AddComponent<FixedJoint>();
        holdingPoint.connectedBody = currentlyHeldObject.GetComponent<Rigidbody>();

        //currentlyHeldObject.transform.parent = _camera.transform;
        //currentlyHeldObject.GetComponent<Rigidbody>().isKinematic = true;
    }

    public void releaseObj()
    {
        //currentlyHeldObject.transform.parent = null;
        //currentlyHeldObject.GetComponent<Rigidbody>().isKinematic = false;
        Destroy(holdingPoint);
        currentlyHeldObject = null;
    }


}
