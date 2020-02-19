using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public GameObject Portal1;
    public GameObject Portal2;
    GameObject player;

    void Start()
    {
        player = GameObject.Find("Player");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            player.GetComponent<Transform>().position = Portal2.GetComponent<Transform>().position;
        }
    }
}
