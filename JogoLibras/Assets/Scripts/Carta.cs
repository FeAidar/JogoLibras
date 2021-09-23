using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carta : MonoBehaviour
{
    public string Significado;
    public bool par;
    private bool virado;
    [SerializeField] private GameObject[] lado;
    private GameObject canvas;

    private void Start(){
        canvas = GameObject.FindGameObjectWithTag("canvas");
        lado[0].SetActive(true);
        lado[1].SetActive(false);
    }

    public void clica(){
        if(virado){
            canvas.GetComponent<CartaManege>().CartaDesselecionada(this.gameObject);
        }else{
            canvas.GetComponent<CartaManege>().CartaSelecionada(this.gameObject);
        }
    }

    public void verso(){
        virado = false;
        lado[0].SetActive(true);
        lado[1].SetActive(false);
    }
    public void frente(){
        virado = true;
        lado[1].SetActive(true);
        lado[0].SetActive(false);
    }
}