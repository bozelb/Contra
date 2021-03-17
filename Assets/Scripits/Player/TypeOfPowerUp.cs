using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypeOfPowerUp : MonoBehaviour
{

        public Fire fire;
        public PlayerMove timer;

        public enum PowerUpType
        {
            MACHINEGUN,
            SHOTGUN,
            ARMOR,
            LIVES
        }
        public PowerUpType currentPowerUp;

        private void Start()
        {
            //Get compents from other objects
            GetComponent<BoxCollider2D>();
            fire = GameObject.FindObjectOfType<Fire>();
            timer = GameObject.FindObjectOfType<PlayerMove>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Player")
            {

                switch (currentPowerUp)
                {
                    case PowerUpType.MACHINEGUN:
                        // When player hits powerUps its starts timer 
                        // and will destory obj
                        // Timer is located in player move 
                        Destroy(gameObject);
                        Debug.Log("MachineGun");
                        break;
                case PowerUpType.SHOTGUN:
                    Destroy(gameObject);
                    Debug.Log("ShotGun");
                    break;
                case PowerUpType.ARMOR:
                    Destroy(gameObject);
                    Debug.Log("Armor");
                    break;
                case PowerUpType.LIVES:
                    //timer.lives++;
                    Destroy(gameObject);
                    Debug.Log("Lives");
                    break;

                }
               

            }
        }
    }


