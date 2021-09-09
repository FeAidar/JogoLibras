using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComparaCarta : MonoBehaviour
{
    private List<GameObject> _cartas = new List<GameObject>();
    private bool uma, duas, nenhuma = true;

    private void veri(){
        if(_cartas[1].GetComponent<testandoClick>().Type == _cartas[0].GetComponent<testandoClick>().Type){
            _cartas[1].GetComponent<testandoClick>().par = true;
            _cartas[0].GetComponent<testandoClick>().par = true;
            RemoveAllu();
        }else{
            uma = false;
            duas = true;
        }
    }
    public void AdicionaCarta(GameObject carta){
        if(duas == false){
            _cartas.Add(carta);
            Debug.Log("adiciona");
            if(_cartas != null){
                if(nenhuma){
                    _cartas[0].GetComponent<testandoClick>().a = _cartas.Count -1;
                    _cartas[0].GetComponent<testandoClick>().flip();
                    nenhuma = false;
                    uma = true;
                }else if(uma == true && nenhuma == false){
                    if(_cartas.Count > 1){
                        _cartas[1].GetComponent<testandoClick>().a = _cartas.Count -1;
                        _cartas[1].GetComponent<testandoClick>().flip();
                        uma = false;
                        veri();
                    }
                }
            }
        }else{
            Debug.Log("n pode");
        }
    }
    public void RemoveCarta(int a){
        if(_cartas != null && a < _cartas.Count){
            _cartas[a].GetComponent<testandoClick>().flip();
            _cartas[a].GetComponent<testandoClick>().a = 0;
            _cartas.Remove(_cartas[a]);
            Debug.Log("removeu");
            if(uma == true){
                nenhuma = true;
                uma = false;
                duas = false;
            }
            if(duas == true){
                nenhuma = false;
                uma = true;
                duas = false;
            }
        }
    }
    public void RemoveAllu(){
        nenhuma = true;
        uma = false;
        duas = false; 
        if(_cartas !=null){
            _cartas.Clear();
        } 
    }
}
