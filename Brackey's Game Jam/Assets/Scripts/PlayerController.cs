using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Rigidbody2D rb;
    public Transform playerPos;
    public GameObject groundCheck;

    public float moveSpeed = 5f;
    public float jumpPower = 5f;

    public bool isGrounded;

    Vector2 movement;

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Ground")
        {
            isGrounded = true;
        }
    }
    void FixedUpdate()
    {
        // Main Player Movement

        if(Input.GetKey(KeyCode.D))
        {
            playerPos.position += Vector3.right * moveSpeed * Time.fixedDeltaTime;
        }

        if (Input.GetKey(KeyCode.A))
        {
            playerPos.position += Vector3.left * moveSpeed * Time.fixedDeltaTime;
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Jump();
        }
    }

    void Jump()
    {
        rb.AddForce(new Vector2(0f, 1f) * jumpPower, ForceMode2D.Impulse);
        isGrounded = false;
    }
}
