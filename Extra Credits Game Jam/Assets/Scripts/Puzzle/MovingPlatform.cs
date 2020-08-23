using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Puzzle
{
    public class MovingPlatform : MonoBehaviour
    {
        [SerializeField] Transform leftBorder = null, rightBorder = null;
        [SerializeField] Transform bottomBorder = null, topBorder = null;

        [SerializeField] bool isVertical = false;

        Rigidbody2D rb = null;

        [SerializeField] [Range(0f, 1000f)] float speed = 10f;

        bool movePositive = true;

        private void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            if (!isVertical)
            {
                rb.velocity = new Vector2(-speed, 0);
            }
            else
            {
                rb.velocity = new Vector2(0, speed);
            }
        }

        private void FixedUpdate()
        {
            if (!isVertical)
            {
                if (transform.position.x >= rightBorder.position.x)
                {
                    movePositive = false;
                }
                else if (transform.position.x <= leftBorder.position.x)
                {
                    movePositive = true;
                }

                if (movePositive)
                {
                    rb.MovePosition(new Vector2(transform.position.x + speed, transform.position.y));
                }
                else
                {
                    rb.MovePosition(new Vector2(transform.position.x - speed, transform.position.y));
                }
            }
            else
            {
                if (transform.position.y >= topBorder.position.y)
                {
                    movePositive = false;
                }
                else if (transform.position.y <= bottomBorder.position.y)
                {
                    movePositive = true;
                }

                if (movePositive)
                {
                    rb.MovePosition(new Vector2(transform.position.x, transform.position.y + speed));
                }
                else
                {
                    rb.MovePosition(new Vector2(transform.position.x, transform.position.y - speed));
                }
            }
        }
    }
}