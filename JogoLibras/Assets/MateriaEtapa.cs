using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MateriaEtapa : MonoBehaviour
{
    private TMP_Text texto;
    private GameDefiner opa;
    void Start()
    {
        opa = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameDefiner>();
        texto = GetComponent<TMP_Text>();
        if(opa.Etapa == 1){
            texto.text = "";
        }
    }

}
