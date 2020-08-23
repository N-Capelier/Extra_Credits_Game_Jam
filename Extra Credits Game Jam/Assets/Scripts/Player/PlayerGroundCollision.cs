using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerGroundCollision : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Solid") || collision.CompareTag("Chest") || collision.CompareTag("Moving Solid"))
            {
                PlayerManager.Instance.controller.groundCount++;
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.CompareTag("Solid") || collision.CompareTag("Chest") || collision.CompareTag("Moving Solid"))
            {
                PlayerManager.Instance.controller.groundCount--;
            }
        }

    }
}