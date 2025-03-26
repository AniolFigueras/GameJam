using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPersonaje : MonoBehaviour
{
    public float speedX = 3f;
    public float jumpForce = 10f;

    private Rigidbody2D rb2d;
    private SpriteRenderer spr;
    private bool facingRight;
    public bool isGroundTouched = false;
    public float shieldPositionX = 0;
    private GameObject shieldObject;
    public Habilidad hability;
    float horizontal;

    public Animator anim;
    public Life life;
    public GameObject pers;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        spr = GetComponent<SpriteRenderer>();

        facingRight = true;
        shieldObject = transform.Find("Shield").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        if(Input.GetKey(KeyCode.UpArrow) && isGroundTouched){
            rb2d.velocity = new Vector2 (0.0f, jumpForce);
            anim.SetTrigger("Jump");
            isGroundTouched = false;
        }
        if(horizontal < 0)
        {
            if(!hability.activo)rb2d.velocity = new Vector2 (speedX * horizontal, rb2d.velocity.y);
            facingRight = false;
            spr.flipX = !facingRight;
            Vector3 shieldPosition = shieldObject.transform.localPosition;
            shieldPosition.x = -shieldPositionX;
            shieldObject.transform.localPosition = shieldPosition;
            anim.SetBool("isRunning", true);
        }
        if(horizontal > 0)
        {
            if(!hability.activo)rb2d.velocity = new Vector2 (speedX * horizontal, rb2d.velocity.y);
            facingRight = true;
            spr.flipX = !facingRight;
            Vector3 shieldPosition = shieldObject.transform.localPosition;
            shieldPosition.x = shieldPositionX;
            shieldObject.transform.localPosition = shieldPosition;
            anim.SetBool("isRunning", true);
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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet") && !hability.activo)
        {
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