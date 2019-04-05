using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraControl : MonoBehaviour
{
    public float lookSensitivity;

    private float _deltaX;
    private float _deltaY;
    private Camera _camera;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        _camera = this.GetComponentInChildren<Camera>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void Look()
    {
        _deltaX = Input.GetAxis("Mouse X");
        _deltaY = Input.GetAxis("Mouse Y");
        _camera.transform.Rotate(-_deltaY * lookSensitivity, 0f, 0f);
        this.transform.Rotate(0f, _deltaX * lookSensitivity, 0f);
    }

    private void FixedUpdate()
    {
        Look();
    }
}
