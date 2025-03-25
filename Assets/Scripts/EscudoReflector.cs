using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscudoReflector : MonoBehaviour
{

    public GameObject shield;
    public bool activo;

    float cooldown = 0.3f;
    float currTime = 0f;
    // Start is called before the first frame update
    void Start()
    {
        shield.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(activo)
        {
            shield.gameObject.SetActive(true);
            currTime += Time.deltaTime;
            if(currTime >= cooldown)
            {
                shield.gameObject.SetActive(false);
                activo = false;
                currTime = 0f;
            }
        }
    }
    private void UpdateEscudo()
    {
        
    }
}
