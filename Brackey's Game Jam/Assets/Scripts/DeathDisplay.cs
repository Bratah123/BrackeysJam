using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathDisplay : MonoBehaviour
{

    public Text DeathCounter;

    void Update()
    {
        DeathCounter.text = PlayerController.deathAmount.ToString();
    }

}
