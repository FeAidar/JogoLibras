using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PassaGrupos : MonoBehaviour
{
    [SerializeField]private Scrollbar _sbar;
    [SerializeField]private float distancia;
    
    public void BotaoDireita(){
        _sbar.GetComponent<Scrollbar>().value =_sbar.GetComponent<Scrollbar>().value + distancia;
    }
    public void BotaoEsquerda(){
        _sbar.GetComponent<Scrollbar>().value =_sbar.GetComponent<Scrollbar>().value - distancia;
    }
}
