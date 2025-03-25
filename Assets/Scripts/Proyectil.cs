using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectil : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    public bool izquierda = true;
    public GameObject proyectil;
    bool devuelve;
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
    void Update()
    {
        if(devuelve) 
        {
            devuelve = false;
            
        }
        Destroy(proyectil, 10);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Destroy(proyectil);
        }
        if(collision.gameObject.tag == "Shield")
        {
            Debug.Log("Homerun!");
            devuelve = true;
        }
    }

}
