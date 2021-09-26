using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class telavitoria : MonoBehaviour
{
    [SerializeField]private int essacena;
    [SerializeField]private int hud;
    void Aweke()
    {
        Time.timeScale = 0f;
    }

    public void reload(){
        Time.timeScale= 1f;
        SceneManager.LoadScene(essacena);
    }
    public void mainmenu(){
        Time.timeScale= 1f;
        SceneManager.LoadScene(hud);
    }
}
