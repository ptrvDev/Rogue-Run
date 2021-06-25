using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropLoot : MonoBehaviour
{
    int dropChance;
    GameObject toolkit;

    void Start()
    {
        toolkit = GameObject.FindGameObjectWithTag("Toolkit");
        dropChance = 0;
    }


    void EnemyDead()
    {
        //dropChance = Random.Range(0, 4);
       // if(dropChance >= 2)
        //{
            Instantiate(toolkit, this.transform.position, Quaternion.identity);
           
      //  } else if(2 > dropChance)
       // {
            //dont
       // }
    }
}
