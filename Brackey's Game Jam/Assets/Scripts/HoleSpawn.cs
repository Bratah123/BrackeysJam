using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleSpawn : MonoBehaviour
{
    public GameObject portalPrefab;
    public Transform HolePoint;

    public int maxHoles = 1;
    public int holesAmount;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            GameObject Portal = Instantiate(portalPrefab, HolePoint.transform.position, Quaternion.identity);

            if (holesAmount >= maxHoles)
            {
                Destroy(Portal);
                holesAmount--;
            }
                holesAmount++;
        }

    }
}
