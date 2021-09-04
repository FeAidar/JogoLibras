using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testandoClick : MonoBehaviour
{
    [SerializeField] private GameObject[] _Carta;
    private bool _Cara;
    public float Type;
    public void vira(){
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
