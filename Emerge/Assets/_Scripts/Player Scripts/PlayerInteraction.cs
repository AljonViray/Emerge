using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteraction : MonoBehaviour
{
    public float breakForce;
    public float throwForce;
    public GameObject heldObject;
    public bool onPressurePlate = false;
    public AudioClip throwSound;


    [Header("Private")]
    [SerializeField] private Camera _camera;
    [SerializeField] private GameObject hands;
    [SerializeField] private FixedJoint joint;
    [SerializeField] private Text text;


    // Main Functions //
    private void Update()
    {
        if (LookingAt() != null)
        {
            if(heldObject == null)
            {
                if (LookingAt().GetComponent<PicturePossibleChange>() != null && GameObject.Find("~Photo Minigame~").GetComponent<PhotoParent>().IsPuzzleDone() == false)
                {
                    Debug.Log(LookingAt());
                    LookingAt().GetComponent<PicturePossibleChange>().BeingLookedAt();
                    if(Input.GetKeyDown(KeyCode.E))
                    {
                        LookingAt().GetComponent<PicturePossibleChange>().BeingSelected();
                    }
                }
            }

            //Pick up object
            if (heldObject == null && Input.GetKeyDown(KeyCode.E))
            {
                if (LookingAt().GetComponentInParent<InteractableObject>() != null
                    && LookingAt().GetComponentInParent<InteractableObject>() == true
                    || LookingAt().tag == "Pickupable")
                {
                    LookingAt().GetComponentInParent<InteractableObject>().Interact(this);
                }
            }

            else if (heldObject != null)
            {
                //Drop held object
                if (Input.GetKeyDown(KeyCode.E)) ReleaseObj();

                //Throw held object
                else if (Input.GetKeyDown(KeyCode.Mouse0)) ThrowObj();
            }
        }

        else if (heldObject != null)
        {
            //If joint breaks due to force, drop object
            if (joint == null) ReleaseObj();

            //Drop held object (not looking at it)
            else if (Input.GetKeyDown(KeyCode.E)) ReleaseObj();

            //Throw held object (not looking at it)
            else if (Input.GetKeyDown(KeyCode.Mouse0)) ThrowObj();
        }
    }


    // Helper Functions //
    public void PickupObj(GameObject objToPickup)
    {
        if (objToPickup.GetComponent<Rigidbody>().isKinematic == true)
            objToPickup.GetComponent<Rigidbody>().isKinematic = false;

        heldObject = objToPickup;
        heldObject.GetComponent<AudioSource>().Play(); // Play sound when picking up object
        heldObject.transform.position = GameObject.Find("Hands").transform.position;
        GameObject.Find("Hands").GetComponent<Rigidbody>().sleepThreshold = 0f;
        heldObject.transform.rotation = Quaternion.LookRotation(_camera.transform.forward);

        joint = hands.AddComponent<FixedJoint>();
        joint.connectedBody = heldObject.GetComponent<Rigidbody>();
        joint.breakForce = breakForce;
    }

    public void ReleaseObj()
    {
        Destroy(joint);
        heldObject = null;
    }

    public void ThrowObj()
    {
        Destroy(joint);
        if (heldObject.name.Split('_')[0] == "Dart")
            heldObject.GetComponent<AudioSource>().PlayOneShot(throwSound);
        heldObject.GetComponent<Rigidbody>().AddForce(_camera.gameObject.transform.forward * throwForce);
        heldObject = null;
    }

    public GameObject LookingAt()
    {
        Ray ray = new Ray(_camera.transform.position, _camera.transform.forward);

        if (Physics.Raycast(ray, out RaycastHit hit, 4) 
            && (hit.transform.gameObject.GetComponentInParent<InteractableObject>() != null
            || hit.transform.gameObject.CompareTag("Pickupable") 
            || hit.transform.gameObject.CompareTag("Interactable")) )
        {
            // If player not on pressure plate, do not allow to pick up
            if (  (hit.transform.gameObject.name == "Dart_1" || hit.transform.gameObject.name == "Dart_2")
                && !onPressurePlate)
                return null;
            else
            {
                Debug.DrawRay(_camera.transform.position, _camera.transform.forward * hit.distance, Color.yellow);
                if (heldObject == null) text.color = Color.green;
                else text.color = Color.white;
                return hit.transform.gameObject;
            }
        }

        else
        {
            text.color = Color.black;
            return null;
        }
    }
}
