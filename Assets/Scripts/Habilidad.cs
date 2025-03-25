using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Habilidad : MonoBehaviour
{
    public bool activo;
    public GameObject escudo;
    public GameObject escudo1;
    float cooldown = 2;
    float currTime = 0f;
    public bool activoSalto;
    float cooldown2 = 0.01f;
    public float currTime2 = 0f;
    // Start is called before the first frame update
    void Start()
    {
        escudo.gameObject.SetActive(false);
        escudo1.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (activo)
        {
            escudo.gameObject.SetActive(true);
            currTime += Time.deltaTime;
            if (currTime >= cooldown)
            {
                escudo.gameObject.SetActive(false);
                activo = false;
                currTime = 0f;
            }
        }
        if(activoSalto)
        {
            escudo1.gameObject.SetActive(true);
            currTime2 += Time.deltaTime;
            if(currTime2 >= cooldown2)
            {
                escudo1.gameObject.SetActive(false);
                activoSalto = false;
                currTime2 = 0f;
            }
        }

    }
}
