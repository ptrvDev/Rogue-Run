using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaveControl : MonoBehaviour
{
    [SerializeField]
    GameObject Wave2;
    [SerializeField]
    GameObject Wave3;
    [SerializeField]
    GameObject Wave4;
    [SerializeField]
    GameObject BonusWave1;
    [SerializeField]
    GameObject BonusWave2;
    


    int EnemyCount;


    // Start is called before the first frame update
    void Start()
    {
        EnemyCount = 0;

        Wave2.SetActive(false);
        Wave3.SetActive(false);
        Wave4.SetActive(false);
        BonusWave1.SetActive(false);
        BonusWave2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Wave2Trigger();
        Wave3Trigger();
        Wave4Trigger();
        Win();
    }


    void Wave2Trigger()
    {
        if(EnemyCount == 5)
        {
            Wave2.SetActive(true);
        }
    }

    void Wave3Trigger()
    {
        if(EnemyCount >= 10)
        {
            Wave3.SetActive(true);
        }
    }
    void Wave4Trigger()
    {
        if (EnemyCount >= 15)
        {
            Wave4.SetActive(true);
        }
    }

    void Win()
    {

        if(EnemyCount >= 20)
        {
            SceneManager.LoadScene(4);
        }
    }

    void BonusWave1Trigger ()
    {
        BonusWave1.SetActive(true);
    }

    void BonusWave2Trigger()
    {
        BonusWave2.SetActive(true);
    }

    void EnemyKilled()
    {
        EnemyCount += 1;
    }
}
