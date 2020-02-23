using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningPower : MonoBehaviour
{

    public GameObject Lightning;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Destroy(Lightning);
        }
    }
}
