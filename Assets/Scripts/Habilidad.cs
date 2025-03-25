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
    }
}
