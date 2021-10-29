using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class DialogSistem : MonoBehaviour
{
    /*
        1. primeira fala não vai conseguir ter evento
        2. aparecer ou não a verificação se o player quer ou não o tutorial
        3. apos o player clicar a proxima fala é escrite e se tiver evento naquela fala ele é acionado
        4. ao fim o ultimo evento é acionado
    */

    [SerializeField]private string[] falas;
    [SerializeField]private string EmQueFala;
    [SerializeField]private UnityEvent[] eventos;
    [SerializeField]private UnityEvent Nofim;
    [HideInInspector]public bool Action = false;
    private bool chama = true;
    private bool PodeClick= false;
    private List<int> NessaFala = new List<int>();
    private int FalaAtual = 0;
    private int acao;
    private DialogoEscrito dig ;

    private void Start(){
        dig = GetComponent<DialogoEscrito>();
        dig.ComecaFala(falas[FalaAtual]);
        foreach (char d in EmQueFala)
        {
            string f = ""+d;
            NessaFala.Add(int.Parse(f));
        }
    }
    private void Update(){
        if(chama){
            if(falas.Length == FalaAtual){
                Nofim.Invoke();
            }else{
                dig.ComecaFala(falas[FalaAtual]);
            }
            chama = false;
        }
        if(Action){
            if(FalaAtual == NessaFala[acao]){
                Debug.Log("evento");
                eventos[acao].Invoke();
                acao++;
                FalaAtual++;
                Action = false;
                PodeClick = true;
            }else{
                Debug.Log("sem evento");
                Debug.Log(FalaAtual+ " "+  NessaFala[acao]);
                FalaAtual++;
                Action= false;
                PodeClick = true;
            }
        }
        if(Input.GetKeyDown(KeyCode.Mouse0)){
            if(PodeClick){
                chama = true;
                PodeClick = false;
            }
        }
    }
    
}
