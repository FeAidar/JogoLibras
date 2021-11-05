using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DialogoEscrito : MonoBehaviour
{
    [SerializeField]private Text FalaNaTela;
    [SerializeField]private float VelocidadeDaFala;
    private string FalaAtual = "";
    private DialogSistem digo;
    public bool podeclicar;
    private void Start(){
        digo = GetComponent<DialogSistem>();
    }
    public void ComecaFala(string a){
        StartCoroutine(Fala(a));
    }
    IEnumerator Fala(string dialogo){
        for (int i = 0; i < dialogo.Length; i++)
        {
            if(podeclicar)
            if(Input.GetKeyDown(KeyCode.Mouse0)){
                i = 10000;
            }
            FalaAtual = dialogo.Substring(0,i+1);
            FalaNaTela.text = FalaAtual;
            podeclicar = false;
           // Debug.Log(FalaAtual);
            yield return new WaitForSeconds(VelocidadeDaFala);
        }
        if (FalaAtual == dialogo)
        {
            podeclicar = true;
        }
        digo.Action = true;
    }
}
