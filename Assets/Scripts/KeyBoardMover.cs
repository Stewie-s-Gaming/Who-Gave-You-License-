using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBoardMover : MonoBehaviour
{
    [Tooltip("Speed of movement, in meters per second")]
    [SerializeField] float speed;
    Rigidbody rb;
    float left, right;
    SpriteRenderer sr;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        left = -1;
        right = 1;
        sr = GetComponent<SpriteRenderer>();
    }
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal"); // +1 if right arrow is pushed, -1 if left arrow is pushed, 0 otherwise
        float vertical = Input.GetAxis("Vertical");     // +1 if up arrow is pushed, -1 if down arrow is pushed, 0 otherwise
        Vector3 movementVector = new Vector3(horizontal, vertical, 0).normalized;
        if (horizontal == left && !sr.flipX)
        {
            sr.flipX = true;
        }
        else if(horizontal==right && sr.flipX)
        {
            sr.flipX = false;
        }
       
        if (movementVector == Vector3.zero)
        {
            return;
        }
        rb.MovePosition(rb.position + movementVector * Time.fixedDeltaTime * speed);
    }
}
