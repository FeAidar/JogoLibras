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
    private List<GameObject> cartasprontas = new List<GameObject>();
    private List<GameObject> grupos = new List<GameObject>();
    [SerializeField]private float[] Quantia;
    private int i, m;
    private GameObject Definer;
    private int _Dificudade;
    
    void Start()
    {
        Definer = GameObject.FindGameObjectWithTag("GameController");
        if(GameObject.FindGameObjectWithTag("GameController") != null){
            if(Definer.GetComponent<GameDefiner>() != null){
                _Dificudade = Definer.GetComponent<GameDefiner>().Dificuldade;
            }
        }

        grupos.Add(GameObject.FindGameObjectWithTag("g1"));
        grupos.Add(GameObject.FindGameObjectWithTag("g2"));
        grupos.Add(GameObject.FindGameObjectWithTag("g3"));
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
                    GameObject c = Instantiate(a, transform.position, Quaternion.identity);
                    cartasprontas.Add(c);
                    int r = Random.Range(0, grupos.Count);
                    c.transform.SetParent(grupos[r-1].transform);
                }
            }
        }
    }

    private void OutrasPalavras(){
        switch(_Dificudade){
            case 0:
                forpalavras(Quantia[0]);
            break;
            case 1:
                forpalavras(Quantia[1]);
            break;
            case 2:
                forpalavras(Quantia[2]);
            break;
        }
    }

    private void forpalavras(float a){
        bool n = true;
        for (int i = 0; i < a; i++){
        
            if(n == true){
                m = Random.Range(0, SinaisSimples.Length);
                n= false;
            }
            int d = 0;
            foreach(GameObject b in cartasprontas){
                if(SinaisSimples[m].name != b.name){
                    d++;
                }
            }
            if(d >= certas.Count){

                GameObject c = Instantiate(SinaisSimples[m], transform.position, Quaternion.identity);
                cartasprontas.Add(c);
                int r = Random.Range(0, grupos.Count);
                c.transform.SetParent(grupos[r-1].transform);
                n= true;
            }
        }
    }
}
