using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityStandardAssets.CrossPlatformInput;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        [Header("Components")]
        [SerializeField] Rigidbody2D rb = null;
        Animator anim;

        [Header("Variables")]
        [Range(0f, 20f)]
        [SerializeField] float moveSpeed = 5f;

        [Range(0f, 1000f)]
        [SerializeField] float jumpForce = 200f;

        float horizontalMovement = 0f;
        [HideInInspector] public int groundCount = 0;
        [HideInInspector] public bool facingRight = true;
        Vector3 localScale;

        private void Start()
        {
            anim = GetComponent<Animator>();
            localScale = transform.localScale;
        }

        private void Update()
        {
            horizontalMovement = CrossPlatformInputManager.GetAxis("Horizontal") * moveSpeed;

            if (CrossPlatformInputManager.GetButtonDown("Jump") && groundCount > 0)
            {
                rb.AddForce(Vector2.up * jumpForce);
            }

            /* //Animator
            if(Mathf.Abs(horizontalMovement) > 0 && groundCount > 0) //&& rb.velocity.y == 0
            {
                anim.SetBool("isRunning", true);
            }
            else
            {
                anim.SetBool("isRunning", false);
            }
            
            if(rb.velocity.y == 0)
            {
                anim.SetBool("isJumping", false);
                anim.SetBool("isFalling", false);
            }

            if (rb.velocity.y > 0)
            {
                anim.SetBool("isJumping", true);
            }

            if (rb.velocity.y < 0)
            {
                anim.SetBool("isJumping", false);
                anim.SetBool("isFalling", true);
            }
            */
        }

        private void FixedUpdate()
        {
            rb.velocity = new Vector2(horizontalMovement, rb.velocity.y);
        }

        private void LateUpdate()
        {
            if (horizontalMovement > 0f)
            {
                facingRight = true;
            }
            else if (horizontalMovement < 0f)
            {
                facingRight = false;
            }

            if ((facingRight && localScale.x < 0f) || (!facingRight && localScale.x > 0f))
            {
                localScale.x *= -1;
                transform.localScale = localScale;
            }
        }
    }

    public static class Controller
    {
        public static void ChangeGameObjectFacing(this Transform transform)
        {
            if (PlayerManager.Instance.controller.facingRight)
            {
                transform.localScale = Vector3.one;
            }
            else
            {
                transform.localScale = new Vector3(-1f, 1, 1);
            }
        }
    }

}
