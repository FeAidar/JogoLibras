using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelecionaSimbolo : MonoBehaviour
{
    private GameObject maneger, definer;
    [SerializeField]private GameObject borda;
    [SerializeField][Tooltip("0= com escrita, 1= sem escrita")]private Sprite[] imgs;
    public bool selecionado;
    public bool pode = true;
    private void Start(){
        maneger = GameObject.FindGameObjectWithTag("canvas");
        definer = GameObject.FindGameObjectWithTag("GameController");
        if(definer.GetComponent<GameDefiner>().Etapa >= 2){
            GetComponent<Image>().sprite = imgs[1];
            Debug.Log("foi");
        }else{
            GetComponent<Image>().sprite = imgs[0];
        }
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
