using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelecionaSimbolo : MonoBehaviour
{
    private GameObject maneger;
    private bool selecionado;
    private void Start(){
        maneger = GameObject.FindGameObjectWithTag("canvas");
    }
    public void seleciona(){
        if(selecionado == false){
            maneger.GetComponent<WordManege>().SelecionaSimbulo(this.gameObject);
            selecionado = true;
        }else{
            maneger.GetComponent<WordManege>().DesSelecionaSimbulo(this.gameObject);
            selecionado = false;
        }
    }
}
