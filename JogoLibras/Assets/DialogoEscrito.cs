using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class DialogoEscrito : MonoBehaviour
{
    [SerializeField]private TMP_Text FalaNaTela;
    [SerializeField]private float VelocidadeDaFala;
    private float tempo;
    private string FalaAtual = "", fala;
    private DialogSistem digo;
    public bool rolando;
    public int letraAtual;
    private void Start(){
        digo = GetComponent<DialogSistem>();
    }
    public void ComecaFala(string a){
        fala = a;
        letraAtual = 0;
        FalaAtual = "";
        rolando = true;
    }

    void Update(){
        if(rolando == true){
            if(tempo< Time.time){
                FalaAtual = fala.Substring(0,letraAtual+1);
                letraAtual++;
                FalaNaTela.text = FalaAtual;
                if(FalaAtual == fala){
                    digo.Action = true;
                    rolando = false;
                }
                tempo = Time.time + VelocidadeDaFala;
            }
            if(Input.GetKeyDown(KeyCode.Mouse0)){
                FalaAtual = fala;
                FalaNaTela.text = FalaAtual;
                digo.Action = true;
                rolando = false;
            }
        }
    }
}
