using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataforma : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject destination1;
    public GameObject destination2;
    private Transform currentDestination;
    public float speed;
    float x;
    float y;
    public Transform plataforma;
    Vector2 direction;
    // Start is called before the first frame update
    void Start()
    {
        currentDestination = destination1.transform;
        rb = GetComponent<Rigidbody2D>();
        direction = (currentDestination.position - transform.position).normalized;
        x = plataforma.position.x;
        y = plataforma.position.y;  
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = direction*speed;
        ChangeDirection();
    }

    void ChangeDirection()
    {
        if (Vector2.Distance(transform.position, currentDestination.position) < 1.5f && currentDestination.position == destination1.transform.position)
        {
            currentDestination = destination2.transform;
            direction = (currentDestination.position - transform.position).normalized;
        }
        else if(Vector2.Distance(transform.position, currentDestination.position) < 1.5f && currentDestination.position == destination2.transform.position)
        {
            currentDestination = destination1.transform;
            direction = (currentDestination.position - transform.position).normalized;
        }
    }
}
