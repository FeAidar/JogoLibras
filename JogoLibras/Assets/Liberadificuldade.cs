using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Liberadificuldade : MonoBehaviour
{
    public GameObject Facil;
    public GameObject Medio;
    public GameObject Dificil;


    void Start()
    {
        Medio.SetActive(false);
        Dificil.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (PlayerPrefs.GetInt("nivelmochila1")==1)
            {
            Medio.SetActive(true);
            Dificil.SetActive(false);
   
        }

        if (PlayerPrefs.GetInt("nivelmochila1") >= 2)
        {
            Dificil.SetActive(true);
            Medio.SetActive(true);

        }

        if (PlayerPrefs.GetInt("nivelmochila1") ==0)
        {
            Medio.SetActive(false);
            Dificil.SetActive(false);
        }
          
           // Debug.Log(PlayerPrefs.GetInt("nivelmochila1"));

   
    }

    public void Restartprefs()
    {
        PlayerPrefs.SetInt("nivelmochila1", 0);
    }

}
