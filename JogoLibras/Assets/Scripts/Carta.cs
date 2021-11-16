using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Carta : MonoBehaviour
{
    public string Significado;
    public bool par;
    private bool virado;
    [SerializeField][Tooltip("lado 0 = parte de tras da carta, lado 1 = verso normal, lado 2 = verso da figura, lado 3 = verso normal sem a palavra")] private GameObject[] lado;
    private GameObject canvas;
    public bool EtapaSemPalavra;
    public bool essa;
    [SerializeField]private bool Composto;
    private bool CoTrue;
    [SerializeField]private Sprite[] imaCo;
    [SerializeField]private float TempoCompos;
    private float tempoCo;
    private int a;

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
                CoTrue=false;
                lado[0].SetActive(true);
                lado[3].SetActive(false);
            }else{
                CoTrue=false;
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
                if(Composto==true){
                    CoTrue=true;
                }
                lado[3].SetActive(true);
                lado[0].SetActive(false);
            }else{
                if(Composto==true){
                    CoTrue=true;
                }
                lado[1].SetActive(true);
                lado[0].SetActive(false);
            }
        }else if(essa == true){
            lado[2].SetActive(true);
            lado[0].SetActive(false);
        }
    }
    private void Update(){
        if(CoTrue== true){
            if(tempoCo <Time.time){
                if(EtapaSemPalavra){
                    lado[3].transform.GetChild(0).GetComponent<Image>().sprite = imaCo[a];
                }else{
                    lado[1].transform.GetChild(0).GetComponent<Image>().sprite = imaCo[a];
                }
                if(a==0){
                    a = 1;
                }else{
                    a=0;
                }
                tempoCo = Time.time + TempoCompos;
            }
        }
    }
    
}
