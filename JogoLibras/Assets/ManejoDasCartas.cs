using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManejoDasCartas : MonoBehaviour
{
    [SerializeField]private GameObject[] _Cartas;
    [SerializeField]private Sprite[] _Sprites;
    private int _Carta,type, dupla;
    private Vector3 _away = new Vector3(1000f, 1000f, 0f);
    private bool a;

    private void Start(){
        SetCarts();
    }
    private void Update(){
        int types = _Sprites.Length;
        int length = _Cartas.Length;
        if(a){
            if(type <= types){
                if(type<=types){
                    if(dupla < 2){
                        GameObject verso = _Cartas[_Carta].transform.GetChild(1).gameObject;
                        verso.GetComponent<SpriteRenderer>().sprite = _Sprites[type];
                        _Carta +=1;
                        dupla +=1;
                    }else{
                        type +=1;
                        dupla =0;
                    } 
                }else{

                    _Cartas[_Carta].transform.Translate(_away, Space.World);
                    _Carta +=1;
                }
            }else{
                a= false;
            }
        }
        if(_Carta >= length){
            a = false;
        }
    }
    public void Scrumble(){

    }

    public void SetCarts(){
        a = true;
    }
}
