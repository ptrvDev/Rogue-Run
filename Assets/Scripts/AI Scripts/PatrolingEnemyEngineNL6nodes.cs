using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolingEnemyEngineNL6nodes : MonoBehaviour
{
    //L at the end stands for Linear as in "Linear Patroling"
    private float speed = 5;
    private int health;

    [SerializeField]
    Transform[] nodes;

    Rigidbody2D EnemyRb;

    private int currentNode;
    private int numberOfNodes;

    private float shootingDistance = 4.4f;
    private bool enemyIsShooting;
    private float shootingTime;
    private float shootingTimeValue = 0.75f;




    public Transform player1;
    public GameObject projectile1;



    GameObject WaveCtrl;

    [SerializeField]
    GameObject toolkit;

    int dropChance;



    void Start()
    {
        dropChance = 0;

        EnemyRb = GetComponent<Rigidbody2D>();
        health = 75;

        currentNode = 0;
        numberOfNodes = nodes.Length;


        enemyIsShooting = false;
        shootingTime = shootingTimeValue;

        WaveCtrl = GameObject.FindGameObjectWithTag("waveControl");

        



    }



    void Update()
    {

        Patrol();
        Death();
        Shoot();
    }




    void Patrol()
    {
        if (enemyIsShooting == false)
        {
            EnemyRb.transform.position = Vector2.MoveTowards(EnemyRb.transform.position, nodes[currentNode].position, speed * Time.deltaTime);

            if (Vector2.Distance(EnemyRb.transform.position, nodes[currentNode].position) < 0.001f)
            {
                if (currentNode < numberOfNodes - 1)
                {
                    currentNode += 1;
                    Debug.Log(currentNode);
                }

                else if (currentNode == numberOfNodes - 1)
                {
                    Debug.Log("lastnode");
                    currentNode = 2;
                }
            }
        }
        else if (enemyIsShooting == true)

        {
            transform.position = this.transform.position;
        }

    }



    void Shoot()
    {

        if (Vector2.Distance(transform.position, player1.position) < shootingDistance)
        {

            enemyIsShooting = true;

            if (shootingTime <= 0)
            {
                Instantiate(projectile1, transform.position, Quaternion.identity);
                shootingTime = shootingTimeValue;
            }
            else
            {
                shootingTime -= Time.deltaTime;
            }

        }


        if (Vector2.Distance(transform.position, player1.position) > shootingDistance)
        {
            enemyIsShooting = false;
        }

    }



    void Death()
    {
        if (health == 0)
        {
            WaveCtrl.SendMessage("EnemyKilled");
            Destroy(gameObject);

            dropChance = Random.Range(0, 2);

            if (dropChance == 1 || dropChance == 2)
            {
                Instantiate(toolkit, this.transform.position, Quaternion.identity);
                Debug.Log("Instantiated");
            }
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
