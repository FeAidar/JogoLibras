using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testandoClick : MonoBehaviour
{
    [SerializeField] private GameObject[] _Carta;
    private bool _Cara;
    public bool par;
    public int a;
    public float Type;
    private GameObject comp;

    private void Start(){
        comp = GameObject.FindGameObjectWithTag("GameController");
    }
    public void vira(){
        if(par == false){
            if(_Cara){
                comp.GetComponent<ComparaCarta>().RemoveCarta(a);
            }else{
                comp.GetComponent<ComparaCarta>().AdicionaCarta(this.gameObject);
            }
        }
    }
    public void flip(){
        if(_Cara){
            _Carta[0].SetActive(true);
            _Carta[1].SetActive(false);
            _Cara = false;
        }else{
            _Carta[1].SetActive(true);
            _Carta[0].SetActive(false);
            _Cara = true;
        }
    }
    
    
}