using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction { NONE, UP, LEFT, RIGHT };
public class MovimientoPersonaje : MonoBehaviour
{
    public float speedX = 3f;
    public float speedY = 3f;
    public float jumpForce = 10f;

    private Rigidbody2D rb2d;
    private bool isGroundTouched = false;

    public Direction direction = Direction.NONE;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateDirection();
    }

    private void FixedUpdate()
    {
        if (rb2d == null) { return; } 

        float hInput = 0;

        switch (direction)
        {
            case Direction.LEFT:
                hInput = -1;
                break;
            case Direction.RIGHT:
                hInput = 1;
                break;
            default:
                break;
        }

        rb2d.velocity = new Vector2(hInput * speedX, rb2d.velocity.y);
    }

    private void UpdateDirection()
    {
        direction = Direction.NONE;
        int horizontal = 0;
        
        if (Input.GetKey(KeyCode.LeftArrow)) { horizontal -= 1; }
        if (Input.GetKey(KeyCode.RightArrow)) { horizontal += 1; }

        if (horizontal < 0)
        {
            direction = Direction.LEFT;
        }
        else if (horizontal > 0)
        {
            direction = Direction.RIGHT;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && isGroundTouched)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);
            isGroundTouched = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGroundTouched = true;
        }
    }
}