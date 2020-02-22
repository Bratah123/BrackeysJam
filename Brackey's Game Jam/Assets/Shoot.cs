using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{

    public GameObject cannonBall;
    public Transform firePoint;

    public float cannonBallSpeed = 10f;

    public float shootSpeed = 1f;
    public float nextShot;

    void Update()
    {
        if(Time.time > nextShot)
        {
            nextShot = Time.time + shootSpeed;
            GameObject Ball = Instantiate(cannonBall, firePoint.position, Quaternion.identity);

            Ball.GetComponent<Rigidbody2D>().AddForce(Vector2.right * cannonBallSpeed, ForceMode2D.Impulse);

            Destroy(Ball, 3f);
        }
    }
}
