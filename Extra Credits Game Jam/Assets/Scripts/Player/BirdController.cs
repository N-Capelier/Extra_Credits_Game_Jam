using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    [SerializeField] Transform follow = null;
    Rigidbody2D rb = null;
    SpriteRenderer sprite = null;

    [SerializeField] float wayPointDistance = 1f;
    [SerializeField] float speed = 10f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        if(Vector2.Distance(transform.position, follow.position) > wayPointDistance)
        {
            MoveTowardsWayPoint();
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }

    void MoveTowardsWayPoint()
    {
        rb.velocity = new Vector2((follow.position.x - transform.position.x), (follow.position.y - transform.position.y)).normalized * speed;
    }

    private void Update()
    {
        if(rb.velocity.x > 0)
        {
            sprite.flipX = true;
        }
        else
        {
            sprite.flipX = false;
        }
    }
}
