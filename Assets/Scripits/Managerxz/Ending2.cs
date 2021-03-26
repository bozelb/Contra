using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ending2 : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" && GameManager.instance.turretCounter == 12 && GameManager.instance.walkerCounter == 10)
        {
            GameManager.instance.secretEnding();
        }
    }
}
