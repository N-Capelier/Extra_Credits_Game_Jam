using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundCollision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Solid"))
        {
            PlayerManager.Instance.controller.groundCount++;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Solid"))
        {
            PlayerManager.Instance.controller.groundCount--;
        }
    }

}
