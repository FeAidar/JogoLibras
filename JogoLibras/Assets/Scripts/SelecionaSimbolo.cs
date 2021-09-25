using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelecionaSimbolo : MonoBehaviour
{
    private GameObject maneger;
    [SerializeField]private GameObject borda;
    public bool selecionado;
    public bool pode = true;
    private void Start(){
        maneger = GameObject.FindGameObjectWithTag("canvas");
    }
    private void Update(){
        if(selecionado == true){
            borda.SetActive(true);
        }else{
            borda.SetActive(false);
        }
    }
    public void seleciona(){
        if(pode == true){
            if(selecionado == false){
                maneger.GetComponent<WordManege>().SelecionaSimbulo(this.gameObject);
                
            }else{
                maneger.GetComponent<WordManege>().DesSelecionaSimbulo(this.gameObject);
                
            }
        }
    }
}
