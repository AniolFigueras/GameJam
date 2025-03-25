using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectil : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    public bool izquierda = true;
    public GameObject proyectil;
    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        if (izquierda) 
        {
            rb.velocity = new Vector2(speed * (-1), rb.velocity.y);
        }
        if (!izquierda) 
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
        } 
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        Destroy(proyectil, 10);
    }
    public void ChangeDirection()
    {
        rb.velocity = new Vector2(rb.velocity.x * -1, rb.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Destroy(proyectil);
        }
    }

}
