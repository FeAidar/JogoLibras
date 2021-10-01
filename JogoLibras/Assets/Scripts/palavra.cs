using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class palavra : MonoBehaviour
{
    public string Palavra;
    [SerializeField][Tooltip("")]private GameObject[] etapas;
    
    private void Start(){
        if(GameObject.FindGameObjectWithTag("GameController").GetComponent<GameDefiner>().Etapa >= 2){
            etapas[0].SetActive(false);
            etapas[1].SetActive(true);
        }else{
            etapas[1].SetActive(false);
            etapas[0].SetActive(true);
        }
    }
}
