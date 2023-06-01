using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class JumpController : MonoBehaviour
{
    public Transform groundCheck;
    [SerializeField]public LayerMask ground;
    private Rigidbody rb;
    public float jumpForce;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump") && isGrounded())
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
        }


        bool isGrounded()
        {
            return Physics.CheckSphere(groundCheck.position, .5f, ground);
        }
    }
}
