using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public Image StaminaBar;

    public GameObject[] vidas;

    public Habilidad escudo;
    bool rellenar = false;
    int cooldown = 3;
    float next = 0f;
    float currTime2 = 0f;
    int veces = 0;
    public MovimientoPersonaje mov;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow) &&GameManager.instance.Stamina >= 20)
        {
            GameManager.instance.Stamina -= GameManager.instance.AttackCost;
            StaminaBar.fillAmount = GameManager.instance.Stamina / GameManager.instance.MaxStamina;
            escudo.activo = true;
            next = Time.time;
            rellenar = false;
            currTime2 = 0f;
        }
        if (escudo.activo && Input.GetKeyDown(KeyCode.UpArrow) && GameManager.instance.Stamina >= 20)
        {
               escudo.activoSalto = true;
               GameManager.instance.Stamina -= GameManager.instance.AttackCost;
               StaminaBar.fillAmount = GameManager.instance.Stamina / GameManager.instance.MaxStamina;
               next = Time.time;
               rellenar = false;
               currTime2 = 0f; 
        }
        if (GameManager.instance.Stamina < 0) GameManager.instance.Stamina = 0;
        
        if(Time.time >= next + cooldown && GameManager.instance.Stamina < 100)
        {
            rellenar = true;
        }
        if(rellenar)
        {
            currTime2 += Time.deltaTime;
            if(currTime2 >= 1){
                veces +=1;
                currTime2 = 0f;
                GameManager.instance.Stamina += GameManager.instance.ChargeRate;
                StaminaBar.fillAmount = GameManager.instance.Stamina / GameManager.instance.MaxStamina;
                if(veces >= 3)
                {
                    currTime2 = 0f;
                    veces = 0;
                    rellenar = false;
                }
            }
        }

    }

}
