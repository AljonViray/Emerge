using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movespeed;
    //public float jumpForce;

    private Rigidbody _rb;
    private float _deltaX;
    private float _deltaY;
    [SerializeField] private bool canJump;


    // Main Functions //


    void Start()
    {
        _rb = this.GetComponent<Rigidbody>();
    }

    void Update()
    {
        _deltaX = Input.GetAxisRaw("Horizontal");
        _deltaY = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        Move();
        //if (canJump && Input.GetKeyDown(KeyCode.Space)) Jump();
    }


    // Public Functions //


    public void Move()
    {
        Vector3 moveHorizontal = transform.right * _deltaX;
        Vector3 moveVertical = transform.forward * _deltaY;
        Vector3 velocity = (moveHorizontal + moveVertical).normalized * movespeed;
        _rb.velocity = new Vector3(velocity.x, _rb.velocity.y, velocity.z);
    }

    /*
    public void Jump()
    {
        canJump = false;
        _rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
    */


    // Private Functions


    private void OnCollisionStay (Collision collision)
    {
        if (collision.gameObject.tag == "Ground") canJump = true;
    }
}
