using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeEnemy : MonoBehaviour
{
    public int vidas = 2;
    public int vidasMax = 2;
    // Start is called before the first frame update
    void Start()
    {
        vidas = vidasMax;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            Muerte();
        }
    }

    void Muerte()
    {
        vidas--;
        if (vidas <= 0)
        {
            Destroy(gameObject);
        }
    }
}
