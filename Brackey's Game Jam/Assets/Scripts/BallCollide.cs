using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallCollide : MonoBehaviour
{

    public GameObject explosionEffect;
    public GameObject cannonBall;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            PlayerController.deathAmount++;
        }
        else if(collision != null)
        {
            GameObject Explosion = Instantiate(explosionEffect, cannonBall.GetComponent<Transform>().position, Quaternion.identity);
            Destroy(Explosion, .3f);
            Destroy(cannonBall);

        }
    }
}
