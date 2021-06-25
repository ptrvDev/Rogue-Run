using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolkitScript : MonoBehaviour
{
    
    GameObject playerHealth;


    private void Start()
    {


        playerHealth = GameObject.FindGameObjectWithTag("Healthbar");
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("CarCollider"))
        {
            playerHealth.SendMessage("RepairCar");
            Destroy(gameObject);
            
        }
    }

}
