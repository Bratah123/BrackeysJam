using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    public static int deathAmount;

    public bool isGrounded;
    bool facingLeft;
    bool isJumping;

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

        Die();

        mousePos = cam.WorldToScreenPoint(Input.mousePosition);

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            isJumping = true;
        }
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
            player.GetComponent<Animator>().SetBool("isRunning", true);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            playerPos.position += Vector3.left * moveSpeed * Time.fixedDeltaTime;
            facingLeft = true;
            player.GetComponent<SpriteRenderer>().flipX = true;
            player.GetComponent<Animator>().SetBool("isRunning", true);
        }
        else
        {
            player.GetComponent<Animator>().SetBool("isRunning", false);
        }

        if (isJumping)
        {
            isJumping = false;
            Jump();
        }
    }

    void Jump()
    {
        rb.AddForce(new Vector2(0f, 1f) * jumpPower, ForceMode2D.Impulse);
        isGrounded = false;
    }

    void Die()
    {
        if(player.GetComponent<Transform>().position.y < -3f)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            PlayerController.deathAmount++;
        }
    }
}
