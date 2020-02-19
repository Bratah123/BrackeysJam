using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleSpawn : MonoBehaviour
{
    public GameObject portalPrefab;
    public Transform HolePoint;

    public float spawnSpeed = 2.5f;
    private float nextSpawn;

    bool portalActive;

    void Start()
    {
        portalActive = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Fire1") && Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnSpeed;

            GameObject Portal = Instantiate(portalPrefab, HolePoint.transform.position, Quaternion.identity);

            Destroy(Portal, 2f);

        }
        if (Input.GetKey(KeyCode.J) && Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnSpeed;

            GameObject Portal = Instantiate(portalPrefab, HolePoint.transform.position, Quaternion.identity);

            Destroy(Portal, 2f);

        }

    }
}
