using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarCollider : MonoBehaviour
{


    //This class is responsible for the collider box chages when the different car sprites are displayed on the screen 


    bool horizontaltrigger;
    bool verticaltrigger;
    bool diagonal45trigger;
    bool diagonal135trigger;


    void Start()
    {
        horizontaltrigger = false;
        verticaltrigger = false;
        diagonal45trigger = false;
        diagonal135trigger = false;
    }




    void Update()
    {
        if(horizontaltrigger == true && verticaltrigger == false && diagonal45trigger == false && diagonal135trigger == false)
        {
            transform.eulerAngles = Vector3.forward * 180;

        }
        else if(verticaltrigger == true && horizontaltrigger == false && diagonal45trigger == false && diagonal135trigger == false)
        {
            transform.eulerAngles = Vector3.forward * 90;

        }
        else if(diagonal45trigger == true && horizontaltrigger == false && verticaltrigger == false && diagonal135trigger == false)
        {
            transform.eulerAngles = Vector3.forward * 45;

        }
        else if(diagonal135trigger == true && diagonal45trigger == false && horizontaltrigger == false && verticaltrigger == false)
        {
            transform.eulerAngles = Vector3.forward * 135;
        }

      
    }





    void horizontal()
    {
        horizontaltrigger = true;
        verticaltrigger = false;
        diagonal45trigger = false;
        diagonal135trigger = false;
    }

    void vertical()
    {
        horizontaltrigger = false;
        verticaltrigger = true;
        diagonal45trigger = false;
        diagonal135trigger = false;
    }

    void diagonal45()
    {
        horizontaltrigger = false;
        verticaltrigger = false;
        diagonal45trigger = true;
        diagonal135trigger = false;
    }

    void diagonal135()
    {
        horizontaltrigger = false;
        verticaltrigger = false;
        diagonal45trigger = false;
        diagonal135trigger = true;
    }


   
}