using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AttackEnemy : MonoBehaviour
{
    float currTime = 0;
    float currTimeRec = 0;

    public GameObject proy;
    public GameObject enemy;
    public GameObject player;
    public Proyectil proyec;

    bool lanzar = false;
    int lanzados = 0;

    bool noCool = false;

    //Variaciones enemigos
    public bool rojo;
    public bool azul;
    public bool morado;
    float cooldown;
    float cooldownRec;
    public int cantidad;

    int minCan;
    int maxCan;

    float minCool;
    float maxCool;

    float num;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Personaje");
        if (rojo)
        {
            minCan = 1;
            maxCan = 3;
            minCool = 0.2f;
            maxCool = 0.5f;
            cantidad = Random.Range(minCan, maxCan);
            cooldownRec = 3f;
            cooldown = Random.Range(minCool, maxCool);
        }
        else if(azul)
        {
            minCan = 3;
            maxCan = 5;
            minCool = 1f;
            maxCool = 3f;
            cantidad = Random.Range(minCan, maxCan);
            cooldownRec = 5f;
            cooldown = Random.Range(minCool, maxCool);
        }

        else if(morado)
        {
            minCan = 2;
            maxCan = 4;
            minCool = 0.7f;
            maxCool = 1.5f;
            cantidad = Random.Range(minCan, maxCan);
            cooldownRec = 7f;
            cooldown = Random.Range(minCool, maxCool);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null) 
        {
            if (player.transform.position.x > enemy.transform.position.x)
            {
                num = 1.5f;
                proyec.izquierda = false;
                if (player.transform.position.x < 0 && enemy.transform.position.x < 0)
                {
                    if (Mathf.Abs(player.transform.position.x) > Mathf.Abs(enemy.transform.position.x))
                    {
                        num = -1.5f;
                        proyec.izquierda = true;
                    }
                }
            }
            else if (player.transform.position.x < enemy.transform.position.x)
            {
                num = -1.5f;
                proyec.izquierda = true;
            }


            if (currTime == 0 && lanzados < cantidad)
            {
                lanzar = true;
                lanzados++;
            }
            if (lanzar)
            {
                currTime += Time.deltaTime;
                if (currTime >= cooldown)
                {
                    Vector2 direction = new Vector2(enemy.transform.position.x + num, enemy.transform.position.y);
                    GameObject temProy = Instantiate(proy, direction, enemy.transform.rotation);
                    currTime = 0;
                    lanzar = false;
                }
            }
            if (lanzados == cantidad && currTimeRec == 0)
            {
                noCool = true;
            }
            if (noCool)
            {
                currTimeRec += Time.deltaTime;
                if (currTimeRec >= cooldownRec)
                {
                    noCool = false;
                    currTimeRec = 0;
                    lanzados = 0;
                    cantidad = Random.Range(minCan, maxCan);
                }
            }
        }
    }
        
}
