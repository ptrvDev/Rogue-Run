using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialSlowMotion : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if(collision.CompareTag("TutorialSlowMo"))
        {
            Time.timeScale = 0.15f;
            Time.fixedDeltaTime = 0.02f * Time.timeScale;
        }
       
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        Time.timeScale = 1f;
        Time.fixedDeltaTime = 0.02f * Time.timeScale;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.CompareTag("TutorialSlowMo"))
        {
            Time.timeScale = 0.15f;
            Time.fixedDeltaTime = 0.02f * Time.timeScale;
        }

    }
}
