using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
         if (Player)
         {
             Vector3 cameraTransform;
             cameraTransform = transform.position;
             cameraTransform.x = Player.transform.position.x -0.05f;
             cameraTransform.x = Mathf.Clamp(cameraTransform.x, 4.2f, 119.8f);
             transform.position = cameraTransform;
         }
     }
    }

