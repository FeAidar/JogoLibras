using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carta : MonoBehaviour
{
    public string Significado;
    public bool par;
    private bool virado;
    [SerializeField][Tooltip("lado 0 = parte de tras da carta, lado 1 = verso normal, lado 2 = verso da figura, lado 3 = verso normal sem a palavra")] private GameObject[] lado;
    private GameObject canvas;
    public bool EtapaSemPalavra;
    public bool essa;

    private void Start(){
        canvas = GameObject.FindGameObjectWithTag("canvas");
        lado[0].SetActive(true);
        lado[1].SetActive(false);
        lado[2].SetActive(false);
        lado[3].SetActive(false);
    }

    public void clica(){
        
        if(virado == true && par == false){
            canvas.GetComponent<CartaManege>().CartaDesselecionada(this.gameObject);
        }else if(par == false){
            canvas.GetComponent<CartaManege>().CartaSelecionada(this.gameObject);
        }
    }

    public void verso(){
        virado = false;
        if(essa == false){
            if(EtapaSemPalavra){
                lado[0].SetActive(true);
                lado[3].SetActive(false);
            }else{
                lado[0].SetActive(true);
                lado[1].SetActive(false);
            }
        }else if(essa == true){
            lado[0].SetActive(true);
            lado[2].SetActive(false);
        }
    }
    public void frente(){
        virado = true;
        if(essa == false){
            if(EtapaSemPalavra){
                lado[3].SetActive(true);
                lado[0].SetActive(false);
            }else{
                lado[1].SetActive(true);
                lado[0].SetActive(false);
            }
        }else if(essa == true){
            lado[2].SetActive(true);
            lado[0].SetActive(false);
        }
    }
}
