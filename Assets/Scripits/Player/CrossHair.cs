using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossHair : MonoBehaviour
{
    public GameObject cross_Hairs;
   public Vector2 mouse_Pos;
    // Update is called once per frame
    void Update()
    {


        mouse_Pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = mouse_Pos;

    }
}
