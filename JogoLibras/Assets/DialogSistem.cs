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
    [SerializeField]private bool TemEvento;
    [SerializeField]private UnityEvent[] eventos;
    [SerializeField]private UnityEvent Nofim;
    [HideInInspector]public bool Action = false;
    private bool chama = true;
    private bool PodeClick= false;
    private List<int> NessaFala = new List<int>();
    private int FalaAtual = 0;
    private int acao;
    private bool precisa;
    private GameObject definer;
    private DialogoEscrito dig ;

    private void Start(){
        definer = GameObject.FindGameObjectWithTag("GameController");
        precisa = definer.GetComponent<GameDefiner>().dialogo;
        if(precisa == true){
            dig = GetComponent<DialogoEscrito>();
            dig.ComecaFala(falas[FalaAtual]);
            if(TemEvento==true){
                foreach (char d in EmQueFala)
                {
                    string f = ""+d;
                    NessaFala.Add(int.Parse(f));
                }
            }
        }else{
            Nofim.Invoke();
        }
        PodeClick = false;
    }
    private void Update(){
        if(chama){
            if(FalaAtual>= falas.Length){
                Nofim.Invoke();
            }else{
                if(FalaAtual < falas.Length){
                    dig.ComecaFala(falas[FalaAtual]);
                }else if(FalaAtual>= falas.Length){
                    Nofim.Invoke();
                }
            }
            chama = false;
        }
        if(Action){
            if(TemEvento== true){
                if(acao < NessaFala.Count){
                    if(FalaAtual == NessaFala[acao]){
                        eventos[acao].Invoke();
                        acao++;
                        FalaAtual++;
                        Action = false;
                        StartCoroutine(tempoespera());
                    }else{
                        FalaAtual++;
                        Action= false;
                        StartCoroutine(tempoespera());
                    }
                }else{
                    FalaAtual++;
                    Action= false;
                    StartCoroutine(tempoespera());
                }
            }else{
                FalaAtual++;
                Action= false;
                StartCoroutine(tempoespera());
            }
        }
        if(Input.GetKeyDown(KeyCode.Mouse0)){
            if(PodeClick== true){
                chama = true;
                PodeClick = false;
            }
        }
    }
    IEnumerator tempoespera(){
        yield return new WaitForSeconds(2f);
        PodeClick = true;
    }
    
}
