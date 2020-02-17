using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Rigidbody2D rb;
    public Transform playerPos;
    public GameObject groundCheck;
    public Camera cam;

    // The position of where the hole spawns
    public GameObject holePos;

    public float moveSpeed = 5f;
    public float jumpPower = 5f;

    public bool isGrounded;

    Vector2 movement;
    Vector2 mousePos;

    // Update is called once per frame
    void Update()
    {
        if(isGrounded)
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
        }

        if (Input.GetKey(KeyCode.A))
        {
            playerPos.position += Vector3.left * moveSpeed * Time.fixedDeltaTime;
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Jump();
        }

        Vector2 lookDir = mousePos - rb.position;

        float atanAngle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;

        holePos.GetComponent<Rigidbody2D>().rotation = atanAngle;

        Vector3 yTrans = playerPos.transform.position;

        holePos.GetComponent<Transform>().position = playerPos.transform.position;
    }

    void Jump()
    {
        rb.AddForce(new Vector2(0f, 1f) * jumpPower, ForceMode2D.Impulse);
        isGrounded = false;
    }
}
