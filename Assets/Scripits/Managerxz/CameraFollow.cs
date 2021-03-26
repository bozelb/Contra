using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    
    public GameObject Player;
  
    // Update is called once per frame
    void Update()
    {

      if (Player)
        {
            Vector3 cameraTransform;
            cameraTransform = transform.position;
            cameraTransform.x = Player.transform.position.x -0.1f;
            cameraTransform.x = Mathf.Clamp(cameraTransform.x, 3.0f, 119.8f);
            transform.position = cameraTransform;
        }
     
    }


    }

