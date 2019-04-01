using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public GameObject currentEyelineTarget;

    private Camera _camera;
    // Start is called before the first frame update
    void Start()
    {
        _camera = this.GetComponentInChildren<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        LookingAt();

    }

    private void LookingAt()
    {
        RaycastHit hit;
        if (Physics.Raycast(_camera.transform.position, _camera.transform.forward, out hit, Mathf.Infinity))
        {
            Debug.DrawRay(_camera.transform.position, _camera.transform.forward * hit.distance, Color.yellow);
            currentEyelineTarget = hit.transform.gameObject;

        }
        else
        {
            currentEyelineTarget = null;
        }
    }
}
