using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Puzzle
{
    public class WeakPlatform : MonoBehaviour
    {
        public GameObject platform = null;

        [HideInInspector] public bool weakening = false;

        [Range(0f, 10f)]
        [SerializeField] float totalStrength = 2f;

        float strength = 2f;

        [Range(0f, 20f)]
        [SerializeField] float respawnTime = 5f;

        private void Start()
        {
            strength = totalStrength;
        }

        private void Update()
        {
            if(weakening)
            {
                strength -= Time.smoothDeltaTime;
                if (strength <= 0)
                {
                    platform.SetActive(false);
                    weakening = false;
                }
            }

            if(!platform.activeSelf)
            {
                respawnTime -= Time.smoothDeltaTime;
                if(respawnTime <= 0)
                {
                    strength = totalStrength;
                    platform.SetActive(true);
                }
            }

        }
    }
}