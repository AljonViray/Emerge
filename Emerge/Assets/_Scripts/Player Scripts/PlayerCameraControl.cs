using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraControl : MonoBehaviour
{
    public float lookSensitivity;

    private Camera _camera;
    private float _deltaX;
    private float _deltaY;


    // Main Functions //


    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        _camera = this.GetComponentInChildren<Camera>();
    }

    private void LateUpdate()
    {
        _camera.transform.Rotate(Vector3.one * .000000000001f);
        _camera.transform.Rotate(Vector3.one * -.000000000001f);
        Look();
    }


    // Helper Functions //


    private void Look()
    {
        _deltaX = Input.GetAxis("Mouse X");
        _deltaY = Input.GetAxis("Mouse Y");
        _camera.transform.Rotate(-_deltaY * lookSensitivity, 0f, 0f);
        this.transform.Rotate(0f, _deltaX * lookSensitivity, 0f);
    }
}
