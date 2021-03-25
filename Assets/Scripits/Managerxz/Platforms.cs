using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platforms : MonoBehaviour
{
    public PlatformEffector2D effector;

    private void Start()
    {
        effector = GetComponent<PlatformEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKeyDown(KeyCode.S))
        {

            effector.rotationalOffset = 180f;
            StartCoroutine(effectorDelay());
            
        }
    }

    IEnumerator effectorDelay()
    {
        yield return new WaitForSeconds(0.5f);
        effector.rotationalOffset = 0.0f;

    }

    


}