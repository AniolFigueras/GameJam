using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class UI : MonoBehaviour
{
    
    public bool isMainMenu;
    public int menu;

    public GameObject mainMenu;
    public GameObject hudMenu;
    public GameObject escMenu;
    public GameObject optionsMenu;
    public GameObject creditsMenu;

    //Options
    public Slider musicSlider;
    // Start is called before the first frame update
    void Start()
    {
        if(isMainMenu)
        {
            menu = 0;
            mainMenu.gameObject.SetActive(true);
            escMenu.gameObject.SetActive(false);
            optionsMenu.gameObject.SetActive(false);
            hudMenu.gameObject.SetActive(false);
            creditsMenu.gameObject.SetActive(false);
        }
        else
        {
            menu = 3;
            mainMenu.gameObject.SetActive(false);
            escMenu.gameObject.SetActive(false);
            optionsMenu.gameObject.SetActive(false);
            hudMenu.gameObject.SetActive(true);
            creditsMenu.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && !isMainMenu){
            menu = 1;
        }
        if (menu == 0)
        {
            //Menu home
            mainMenu.gameObject.SetActive(true);
            escMenu.gameObject.SetActive(false);
            optionsMenu.gameObject.SetActive(false);
            hudMenu.gameObject.SetActive(false);
            creditsMenu.gameObject.SetActive(false);
            Time.timeScale = 0;
        }
        else if (menu == 1)
        {
            //EscMenu
            mainMenu.gameObject.SetActive(false);
            escMenu.gameObject.SetActive(true);
            optionsMenu.gameObject.SetActive(false);
            hudMenu.gameObject.SetActive(false);
            creditsMenu.gameObject.SetActive(false);
            Time.timeScale = 0;
        }
        else if (menu == 2)
        {
            //OptionsMenu
            mainMenu.gameObject.SetActive(false);
            escMenu.gameObject.SetActive(false);
            optionsMenu.gameObject.SetActive(true);
            hudMenu.gameObject.SetActive(false);
            creditsMenu.gameObject.SetActive(false);
            AudioListener.volume = musicSlider.value;
            Time.timeScale = 0;
        }
        else if (menu == 3)
        {
            //HUD
            mainMenu.gameObject.SetActive(false);
            escMenu.gameObject.SetActive(false);
            optionsMenu.gameObject.SetActive(false);
            hudMenu.gameObject.SetActive(true);
            creditsMenu.gameObject.SetActive(false);
            Time.timeScale = 1;
        }
        else if (menu == 4)
        {
            mainMenu.gameObject.SetActive(false);
            escMenu.gameObject.SetActive(false);
            optionsMenu.gameObject.SetActive(false);
            hudMenu.gameObject.SetActive(false);
            creditsMenu.gameObject.SetActive(true);
        }
    }

    public void Iniciar()
    {
        SceneManager.LoadScene(1);
    }

    public void Opciones()
    {
        menu = 2;
    }

    public void Credits()
    {
        menu = 4;
    }
    public void Salir()
    {
        Application.Quit();
    }

    public void Resume()
    {
        menu = 3;
    }
}
