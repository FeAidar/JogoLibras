using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class transicao : MonoBehaviour
{
    [SerializeField]private Animator anima;

    public void inicia(){
        anima.SetTrigger("end");
    }
    public void finaliza(){
        anima.SetTrigger("start");
    }
}
