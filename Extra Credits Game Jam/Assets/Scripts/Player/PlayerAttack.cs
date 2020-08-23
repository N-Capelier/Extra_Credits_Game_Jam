using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] CapsuleCollider2D capsuleCollider = null;
    [SerializeField] SpriteRenderer sprite = null;
    bool canAttack = true;
    bool isAttacking = false;
    float time = 0f;

    [SerializeField] float attackDuration = 0.5f;
    [SerializeField] float cooldownTime = 1f;

    private void Update()
    {
        if(PlayerManager.Instance.controller.facingRight)
        {
            capsuleCollider.offset = new Vector2(0.8010503f, capsuleCollider.offset.y);
            sprite.gameObject.transform.localPosition = new Vector3(0.672f, 0, 0);
            sprite.flipX = false;
        }
        else
        {
            capsuleCollider.offset = new Vector2(-0.8010503f, capsuleCollider.offset.y);
            sprite.gameObject.transform.localPosition = new Vector3(-0.672f, 0, 0);
            sprite.flipX = true;
        }

        if (CrossPlatformInputManager.GetButtonDown("Attack") && canAttack)
        {
            canAttack = false;
            isAttacking = true;
            time = Time.time;
            capsuleCollider.enabled = true;
            sprite.enabled = true;
        }

        if(isAttacking && Time.time >= time + attackDuration)
        {
            isAttacking = false;
            capsuleCollider.enabled = false;
            sprite.enabled = false;
        }

        if (!canAttack && Time.time >= time + cooldownTime)
        {
            canAttack = true;
        }
    }

    private void LateUpdate()
    {
        transform.ChangeGameObjectFacing();
        //sprite.gameObject.transform.ChangeGameObjectFacing();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))
        {
            //kill the enemy
        }
    }
}
