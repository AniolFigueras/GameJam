using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class NextScene : MonoBehaviour
{
    public bool mapa1;
    public bool mapa2;
    public bool mapa3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (mapa1)
            {
                SceneManager.LoadScene(2);
            }
            else if(mapa2)
            {
                SceneManager.LoadScene(3);
            }
            else if (mapa3)
            {
                SceneManager.LoadScene(0);
            }
        }
    }
}
