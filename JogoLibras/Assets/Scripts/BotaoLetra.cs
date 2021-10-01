using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BotaoLetra : MonoBehaviour
{
    [SerializeField]private int numero;
    [SerializeField][Tooltip("0 = com a letra escrita, 1 = sem a letra escrita")]private Sprite[] etapas;
    public char letra;
    public void aciona(){
        GameObject.FindGameObjectWithTag("canvas").GetComponent<AlfabetoManejo>().BTM_add(numero);
    }
    private void Start(){
        if(GameObject.FindGameObjectWithTag("GameController").GetComponent<GameDefiner>().Etapa == 0){
            GetComponent<Image>().sprite = etapas[0];
        }else{
            GetComponent<Image>().sprite = etapas[1];
        }
    }

}
