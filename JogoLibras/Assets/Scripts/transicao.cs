using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class transicao : MonoBehaviour
{
    [SerializeField]private Animator anima;
    public bool ParaTempo=false;
    public bool FadeInicial = true;

    public void awake()
    {
        if (FadeInicial)
           finaliza();
    }
    public void inicia(){
        anima.SetTrigger("end");
        if(ParaTempo)
        {
            Time.timeScale = 0;
        }
    }
    public void finaliza(){
        anima.SetTrigger("start");

        if(Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }

        if (ParaTempo)
        {
            Time.timeScale = 1;
        }
    }
}
