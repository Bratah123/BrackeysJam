using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Rigidbody2D rb;
    public Transform playerPos;
    public GameObject groundCheck;
    public Camera cam;
    public GameObject player;

    // The position of where the hole spawns
    public GameObject holePos;

    public float moveSpeed = 5f;
    public float jumpPower = 5f;

    public bool isGrounded;
    bool facingLeft;

    Vector2 movement;
    Vector2 mousePos;


    // Update is called once per frame
    void Update()
    {
        Vector3 leftHole = new Vector3(-5.0f, playerPos.position.y, 0f);
        Vector3 rightHole = new Vector3(5.0f, playerPos.position.y, 0f);
        if (isGrounded)
        {
            rb.gravityScale = 2.0f;
        }
        else if(!isGrounded)
        {
            rb.gravityScale = 2.1f;
        }

        mousePos = cam.WorldToScreenPoint(Input.mousePosition);
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
            facingLeft = false;
            player.GetComponent<SpriteRenderer>().flipX = false;
        }

        if (Input.GetKey(KeyCode.A))
        {
            playerPos.position += Vector3.left * moveSpeed * Time.fixedDeltaTime;
            facingLeft = true;
            player.GetComponent<SpriteRenderer>().flipX = true;
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
