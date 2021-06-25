using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthBar : MonoBehaviour
{
    Animator anim;
    float Damage = 20;
    float maxhp;
    float currenthp;
    Scene currentScene;
    string sceneName;

   public  void Start()
    {
        anim = GetComponent<Animator>();
        maxhp = 100;
        currenthp = maxhp;

        currentScene = SceneManager.GetActiveScene();

        sceneName = currentScene.name;
    }


    void Update() //this method is responsible for changing the health bar sprites when damage is inflicted
    {
        if(currenthp == 100)
        {
            anim.SetInteger("DamageTaken", 0);
        }


        if(currenthp == 80)
        {
            anim.SetInteger("DamageTaken", 1);
        }

        if(currenthp == 60)
        {
            anim.SetInteger("DamageTaken", 2);
        }

        if(currenthp == 40)
        {
            anim.SetInteger("DamageTaken", 3);
        }

        if(currenthp == 20)
        {
            anim.SetInteger("DamageTaken", 4);
            
        }

        if (currenthp == 0)
        {
            anim.SetInteger("DamageTaken", 5);
            if (sceneName == "Tutorial Level")
            {
                SceneManager.LoadScene(1);
            }
            else
            {
                EndScreen();
            }
        }
    }


    void SpikesDamage()
    {
        currenthp -= Damage;
    }


    void EnemyDamage()
    {
        currenthp -= Damage;
    }

    void RiverDamage()
    {
        currenthp -= currenthp;
    }

    void RepairCar()
    {
        currenthp += maxhp;
        if(currenthp > maxhp)
        {
            currenthp = maxhp;
        }
    }

    void EndScreen() // show game over screen if health is <= 0 
    {
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
