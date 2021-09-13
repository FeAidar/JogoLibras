using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordManege : MonoBehaviour
{
    /*
        1. seleciona um pack
        2. seleciona um sinal composto
        3. passa os sinais que compoe aquele sinal para a lista de palavras que deverão aparecer em tela
        4. selecionar outros sinais para aparecer na tela 
        5. organiza os sinais nos grupos
    */
    [SerializeField]private GameObject[] PackDeSinaisCompostos;
    [SerializeField]private GameObject[] PackDeSinaisSimples;
    [SerializeField]private List<GameObject> grupos = new List<GameObject>();
    [SerializeField]private int[] Quantia;
    private List<GameObject> SinaisCompostosSelecionados = new List<GameObject>();
    private List<GameObject> SinaisSimplesSelecionados = new List<GameObject>();
    private List<GameObject> SinaisSimplesParaATela = new List<GameObject>();
    private List<GameObject> SinaisCompostoConfirmado = new List<GameObject>();
    private List<GameObject> SinaisSimplesComfirmado = new List<GameObject>();
    private List<GameObject> simboloSelecionado = new List<GameObject>();
    private GameObject Definer;
    private int _Dificudade, _Pack;
    public bool vitoria;
    
    void Start()
    {
        //acha o game controller
        Definer = GameObject.FindGameObjectWithTag("GameController");
        //pega a variavel do game controller
        if(GameObject.FindGameObjectWithTag("GameController") != null){
            if(Definer.GetComponent<GameDefiner>() != null){
                _Dificudade = Definer.GetComponent<GameDefiner>().Dificuldade;
                _Pack = Definer.GetComponent<GameDefiner>().pack;
            }
        }
        seleciona();
        Garantia();
        OutrosSinais();
        RandomPosicao();
        Organiza();
    }

    private void seleciona(){
        int a = PackDeSinaisCompostos[_Pack].transform.childCount;
        for (int i = 0; i < a; i++)
        {
            SinaisCompostosSelecionados.Add(PackDeSinaisCompostos[_Pack].transform.GetChild(i).gameObject);
        }
        int b = PackDeSinaisSimples[_Pack].transform.childCount;
        for (int i = 0; i < b; i++)
        {
            SinaisSimplesSelecionados.Add(PackDeSinaisSimples[_Pack].transform.GetChild(i).gameObject);
        }
        int c = Random.Range(0, SinaisCompostosSelecionados.Count);
        SinaisCompostoConfirmado.Add(SinaisCompostosSelecionados[c]);
    }

    private void Garantia(){
        int a = SinaisCompostoConfirmado[0].GetComponent<ComposteWord>().Composicao.Length;
        foreach (GameObject b in SinaisSimplesSelecionados)
        {
            for (int i = 0; i < a; i++)
            {
                if(b.name == SinaisCompostoConfirmado[0].GetComponent<ComposteWord>().Composicao[i].name){
                    SinaisSimplesParaATela.Add(b);
                    SinaisSimplesComfirmado.Add(b);
                    
                }
            }
        }
        foreach (GameObject b in SinaisSimplesComfirmado)
        {
            SinaisSimplesSelecionados.Remove(b);
        }
    }

    private void OutrosSinais(){
        switch(_Dificudade){
            case 0:
                int a = Quantia[0] - SinaisSimplesParaATela.Count;
                SelecionaOutros(a);
            break;
            case 1:
                a = Quantia[1] - SinaisSimplesParaATela.Count;
                SelecionaOutros(a);
            break;
            case 2:
                a = Quantia[2] - SinaisSimplesParaATela.Count;
                SelecionaOutros(a);
            break;
        }
    }

    private void SelecionaOutros(int a){
        for (int i = 0; i < a; i++)
        {
            int b = Random.Range(0, SinaisSimplesSelecionados.Count-1);
            SinaisSimplesParaATela.Add(SinaisSimplesSelecionados[b]);
            SinaisSimplesSelecionados.Remove(SinaisSimplesSelecionados[b]);
        }
    }

    public void RandomPosicao(){
        for (int i = 0; i < SinaisSimplesParaATela.Count; i++) {
            GameObject temp = SinaisSimplesParaATela[i];
            int randomIndex = Random.Range(i, SinaisSimplesParaATela.Count);
            SinaisSimplesParaATela[i] = SinaisSimplesParaATela[randomIndex];
            SinaisSimplesParaATela[randomIndex] = temp;
        }
    }

    private void Organiza(){
        int b = 0;
        foreach (GameObject a in SinaisSimplesParaATela)
        {
            if(b >= 0 && b<4){
                a.transform.SetParent(grupos[0].transform);
            }else if(b>= 4 && b< 8){
                a.transform.SetParent(grupos[1].transform);
            }else if(b>= 8 && b< 12){
                a.transform.SetParent(grupos[2].transform);
            }else if(b>= 12 && b<= 15){
                a.transform.SetParent(grupos[3].transform);
            }
            b++;
        }
    }

    public void SelecionaSimbulo(){

    }
    public void DesSelecionaSimbulo(){

    }
}
