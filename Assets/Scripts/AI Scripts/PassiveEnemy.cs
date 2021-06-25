using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveEnemy : MonoBehaviour
{
    //L at the end stands for Linear as in "Linear Patroling"
    
    private int health;



    Rigidbody2D EnemyRb;

    private float shootingDistance = 4.4f;
    private bool enemyIsShooting;
    private float shootingTime;
    private float shootingTimeValue = 0.75f;

    public Transform player3;
    public GameObject projectile3;



    [SerializeField]
    GameObject toolkit;

    [SerializeField]
    GameObject TextCtrl;

  



    void Start()
    {

        EnemyRb = GetComponent<Rigidbody2D>();
        health = 75;

        enemyIsShooting = false;
        shootingTime = shootingTimeValue;

    }



    void Update()
    {

        Death();
        Shoot();
    }



    void Shoot()
    {

        if (Vector2.Distance(transform.position, player3.position) < shootingDistance)
        {

            enemyIsShooting = true;

            if (shootingTime <= 0)
            {
                Instantiate(projectile3, transform.position, Quaternion.identity);
                shootingTime = shootingTimeValue;
            }
            else
            {
                shootingTime -= Time.deltaTime;
            }

        }


        if (Vector2.Distance(transform.position, player3.position) > shootingDistance)
        {
            enemyIsShooting = false;
        }

    }



    void Death()
    {
        if (health == 0)
        {
            TextCtrl.SendMessage("ImDead");
            Destroy(gameObject);
            Instantiate(toolkit, this.transform.position, Quaternion.identity);
            Debug.Log("Instantiated");

        }

    }




    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            health -= 25;
        }

    }
}
