using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPersonaje : MonoBehaviour
{
    public float speedX = 3f;
    public float jumpForce = 10f;

    private Rigidbody2D rb2d;
    private bool isGroundTouched = false;
    //New Movement
    float horizontal;

    public Life life;
    public GameObject pers;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        if(Input.GetKey(KeyCode.UpArrow) && isGroundTouched){
            rb2d.velocity = new Vector2 (0.0f, jumpForce);
            
            isGroundTouched = false;
        }
        if(horizontal < 0)
        {
            rb2d.velocity = new Vector2 (speedX * horizontal, rb2d.velocity.y);
            transform.localRotation = Quaternion.Euler(0,180,0);
        }
        if(horizontal > 0)
        {
            rb2d.velocity = new Vector2 (speedX * horizontal, rb2d.velocity.y);
            transform.localRotation = Quaternion.Euler(0,0,0);
        }
        if(horizontal == 0)
        {
            rb2d.velocity = new Vector2(horizontal *0, rb2d.velocity.y);
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGroundTouched = true;
        }
        if(collision.gameObject.CompareTag("Abyss")){
            Vector2 dir = new Vector2(2,0);
            pers.transform.position = dir;
            life.Muerte();
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            isGroundTouched = false;
        }
    }
}