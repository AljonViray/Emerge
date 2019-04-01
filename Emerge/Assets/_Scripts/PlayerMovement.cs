using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float baseMovespeed;
    public float baseJumpForce;

    private Rigidbody _rb;

    private float _deltaX;
    private float _deltaY;
    // Start is called before the first frame update
    void Start()
    {
        _rb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        _deltaX = Input.GetAxisRaw("Horizontal");
        _deltaY = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        Move();
    }

    public void Move()
    {

        _rb.AddRelativeForce(_deltaX * baseMovespeed, 0f, _deltaY * baseMovespeed, ForceMode.VelocityChange);
    }


}
