using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordManege : MonoBehaviour
{
    /*
        1. selecionar um sinal composta
        2. garantir que os sinais que compoe aquela palavra sejam spawnados
        3. gerar as outras x palavras que precisa
        4. organizar elas na tela
    */

    [SerializeField]private GameObject[] SinaisCompostos;
    [SerializeField]private GameObject[] SinaisSimples;
    private List<string> certas = new List<string>();
    private List<GameObject> certasprontas = new List<GameObject>();
    private int i;
    void Start()
    {
        
    }
    void Update()
    {
        
    }

    private void seleciona(){
        int composto = Random.Range(0, SinaisCompostos.Length);
        GameObject palavra = Instantiate(SinaisCompostos[composto], transform.position, Quaternion.identity);
        foreach (GameObject a in palavra.GetComponent<ComposteWord>().Composicao)
        {
            certas.Add(palavra.GetComponent<ComposteWord>().Composicao[i].name);
            i++;
        }
    }
    private void Garantia(){
        foreach(GameObject a in SinaisSimples){
            foreach(string b in certas){
                if(a.name == b){
                    certasprontas.Add(Instantiate(a, transform.position, Quaternion.identity));
                }
            }
        }
    }

    private void OutrasPalavras(){

    }
}
