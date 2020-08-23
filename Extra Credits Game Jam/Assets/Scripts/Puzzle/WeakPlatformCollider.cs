using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Puzzle
{
    public class WeakPlatformCollider : MonoBehaviour
    {
        [SerializeField] WeakPlatform weakPlatform = null;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("PlayerGroundCollider") && weakPlatform.platform.activeSelf)
            {
                weakPlatform.weakening = true;
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.CompareTag("PlayerGroundCollider"))
            {
                weakPlatform.weakening = false;
            }
        }
    }

}