using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComposteWord : MonoBehaviour
{
    public GameObject[] Composicao;
    [SerializeField][Tooltip("0 = texto, 1= imagem")]private GameObject[] etapas;
    public bool imagem;

    private void Start(){
        if(imagem){
            etapas[1].SetActive(true);
            etapas[0].SetActive(false);
        }else{
            etapas[0].SetActive(true);
            etapas[1].SetActive(false);
        }
    }
}
