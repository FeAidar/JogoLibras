using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Liberadificuldade : MonoBehaviour
{
    public GameObject Facil;
    public GameObject Medio;
    public GameObject Dificil;
    private GameDefiner controller;


    void Start()
    {
        Medio.SetActive(false);
        Dificil.SetActive(false);
        controller = FindObjectOfType<GameDefiner>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (PlayerPrefs.GetInt(SceneManager.GetActiveScene().name + controller.Dificuldade)==1)
            {
            Medio.SetActive(true);
            Dificil.SetActive(false);
   
        }

        if (PlayerPrefs.GetInt(SceneManager.GetActiveScene().name + controller.Dificuldade) >= 2)
        {
            Dificil.SetActive(true);
            Medio.SetActive(true);

        }

        if (PlayerPrefs.GetInt(SceneManager.GetActiveScene().name + controller.Dificuldade) ==0)
        {
            Medio.SetActive(false);
            Dificil.SetActive(false);
        }
          
           // Debug.Log(PlayerPrefs.GetInt("nivelmochila1"));

   
    }

    public void Restartprefs()
    {
        PlayerPrefs.SetInt(SceneManager.GetActiveScene().name + controller.Dificuldade, 0);
    }

}
