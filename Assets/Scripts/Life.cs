using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Life : MonoBehaviour
{
    public int vidaas;
    public int maxVidas;
    public GameObject pers;
    public HUD hud;
    // Start is called before the first frame update
    void Start()
    {
        vidaas = maxVidas;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Muerte(){
        vidaas--;
        if (hud.vidas[vidaas] != null) hud.vidas[vidaas].enabled = false;
        if (hud.sinVidas[vidaas] != null) hud.sinVidas[vidaas].enabled = true;
        if(vidaas == 0){
            Destroy(pers);
            SceneManager.LoadScene(0);
        }
    }
}
