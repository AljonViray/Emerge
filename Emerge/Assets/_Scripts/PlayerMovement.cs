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

    void Start()
    {
        _rb = this.GetComponent<Rigidbody>();
    }


    void Update()
    {
        _deltaX = Input.GetAxisRaw("Horizontal");
        _deltaY = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        Move();
        if (Input.GetKeyDown(KeyCode.Space)) Jump();
    }

    public void Move()
    {
        Vector3 moveHorizontal = transform.right * _deltaX;
        Vector3 moveVertical = transform.forward * _deltaY;

        Vector3 velocity = (moveHorizontal + moveVertical).normalized * baseMovespeed;
        _rb.velocity = new Vector3(velocity.x, _rb.velocity.y, velocity.z);
    }

    public void Jump()
    {
        _rb.AddForce(0, baseJumpForce, 0, ForceMode.Impulse);
    }
}
