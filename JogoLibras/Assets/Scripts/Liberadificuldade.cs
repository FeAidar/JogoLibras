using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Liberadificuldade : MonoBehaviour
{
    public GameObject Estrela1;
    public GameObject Estrela2;
    public GameObject Estrela3;
    private GameDefiner controller;


    void Start()
    { 
        Estrela1.SetActive(false);
        Estrela2.SetActive(false);
        Estrela3.SetActive(false);
        controller = FindObjectOfType<GameDefiner>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (PlayerPrefs.GetInt(SceneManager.GetActiveScene().name + controller.Dificuldade_do_Minigame + controller.pack) ==1)
            {
            Estrela1.SetActive(true);
            Estrela2.SetActive(false);
            Estrela3.SetActive(false);

        }

        if (PlayerPrefs.GetInt(SceneManager.GetActiveScene().name + controller.Dificuldade_do_Minigame + controller.pack) == 2)
        {
            Estrela1.SetActive(true);
            Estrela2.SetActive(true);
            Estrela3.SetActive(false);

        }

        if (PlayerPrefs.GetInt(SceneManager.GetActiveScene().name + controller.Dificuldade_do_Minigame + controller.pack) == 3)
        {
            Estrela1.SetActive(true);
            Estrela2.SetActive(true);
            Estrela3.SetActive(true);

        }

        if (PlayerPrefs.GetInt(SceneManager.GetActiveScene().name + controller.Dificuldade_do_Minigame + controller.pack) == 0)
        {
            Estrela1.SetActive(false);
            Estrela2.SetActive(false);
            Estrela3.SetActive(false);
        }
          
           // Debug.Log(PlayerPrefs.GetInt("nivelmochila1"));

   
    }

    public void Restartprefs()
    {
        PlayerPrefs.SetInt(SceneManager.GetActiveScene().name + controller.Dificuldade_do_Minigame + controller.pack, 0);
    }

}
