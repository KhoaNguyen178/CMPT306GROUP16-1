using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderDetector : MonoBehaviour
{
    [SerializeField] private PlayerController player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<LadderMovement>())
        {
            player.ClimbingAllowed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<LadderMovement>())
        {
            player.ClimbingAllowed = false;
        }
    }
}
