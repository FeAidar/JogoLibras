using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetoDoAluno : MonoBehaviour
{
    private GameObject sistema;

    private void Start(){
        sistema = GameObject.FindGameObjectWithTag("Sistema");
    }

    public void click(){
        sistema.GetComponent<TesouroSitemaUm>().Apertou(this.gameObject);
    }
}
