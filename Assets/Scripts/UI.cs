using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UI : MonoBehaviour
{
    public GameObject menuPrin;
    public GameObject menuHud;
    public GameObject menuEsc;
    public GameObject menuOptions;
    public int men = 0;
    public bool mainMen;
    // Start is called before the first frame update
    void Start()
    {
        menuPrin.SetActive(true);
        menuHud.SetActive(false);
        menuEsc.SetActive(false);
        menuOptions.SetActive(false);
        if (mainMen) men = 2;
    }

    // Update is called once per frame
    void Update()
    {

        if(men == 0){
            //HUD
            menuHud.SetActive(true);
            menuEsc.SetActive(false);
            menuOptions.SetActive(false);
            menuPrin.SetActive(false);
        }
        else if(men == 1)
        {
            menuHud.SetActive(false);
            menuEsc.SetActive(true);
            menuOptions.SetActive(false);
            menuPrin.SetActive(false);
        }
        else if (men == 2)
        {
            menuHud.SetActive(false);
            menuEsc.SetActive(false);
            menuOptions.SetActive(false);
            menuPrin.SetActive(true);
        }
    }
    public void Resumen()
    {
        men = 0;   
    }

    public void Esc()
    {
        men = 3;
    }
    public void Salir()
    {
        Application.Quit();
    }
    public void Iniciar()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
