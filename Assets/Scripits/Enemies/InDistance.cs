using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InDistance : MonoBehaviour
{
    Turret turret;

    // Start is called before the first frame update
    void Start()
    {
        turret = GameObject.FindObjectOfType<Turret>();
    }
    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
            turret.inDistance = true;
    }   */
}
