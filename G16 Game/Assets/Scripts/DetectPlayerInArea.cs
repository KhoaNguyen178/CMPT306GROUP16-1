using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPlayerInArea : MonoBehaviour
{
    public bool playerDetected;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerDetected = true;

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerDetected = false;
        }
    }
}