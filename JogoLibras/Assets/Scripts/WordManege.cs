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
    [SerializeField]private List<GameObject> View = new List<GameObject>();
    [SerializeField]private int[] Quantia;
    private List<GameObject> SinaisCompostosSelecionados = new List<GameObject>();
    private List<GameObject> SinaisSimplesSelecionados = new List<GameObject>();
    private List<GameObject> SinaisSimplesParaATela = new List<GameObject>();
    private List<GameObject> SinaisCompostoConfirmado = new List<GameObject>();
    private List<GameObject> SinaisSimplesComfirmado = new List<GameObject>();
    private List<GameObject> simboloSelecionado = new List<GameObject>();
    private GameObject Definer;
    private int _Dificudade, _Pack,_quantia;
    public bool vitoria;
    private int selecionados;
    int abacate;
    void Start()
    {
        //acha o game controller
        Definer = GameObject.FindGameObjectWithTag("GameController");
        //pega a variavel do game controller
        if(GameObject.FindGameObjectWithTag("GameController") != null){
            if(Definer.GetComponent<GameDefiner>() != null){
                _Dificudade = Definer.GetComponent<GameDefiner>().Dificuldade;
                _Pack = Definer.GetComponent<GameDefiner>().pack;
                _quantia = Definer.GetComponent<GameDefiner>().Quantia;
            }
        }
        if(_quantia == 0){
            View[0].SetActive(true);
            View[1].SetActive(false);
            View[2].SetActive(false);
        }else if(_quantia == 1){
            View[1].SetActive(true);
            View[0].SetActive(false);
            View[2].SetActive(false);
        }else if(_quantia == 2){
            View[2].SetActive(true);
            View[0].SetActive(false);
            View[1].SetActive(false);
        }
        seleciona();
        Garantia();
        OutrosSinais();
        RandomPosicao();
        Organiza();
    }

    private void seleciona(){
        GameObject PackCompostoSelecionado = Instantiate(PackDeSinaisCompostos[_Pack], new Vector3(1000f, 1000f,0f), Quaternion.identity);
        int a = PackCompostoSelecionado.transform.childCount;
        for (int i = 0; i < a; i++)
        {
            SinaisCompostosSelecionados.Add(PackCompostoSelecionado.transform.GetChild(i).gameObject);
        }
        GameObject PackSimplesSelecionado = Instantiate(PackDeSinaisSimples[_Pack], new Vector3(1000f, 1000f,0f), Quaternion.identity);
        int b = PackSimplesSelecionado.transform.childCount;
        for (int i = 0; i < b; i++)
        {
            SinaisSimplesSelecionados.Add(PackSimplesSelecionado.transform.GetChild(i).gameObject);
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
        switch(_quantia){
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
        foreach (GameObject a in SinaisSimplesParaATela)
        {
            if(_quantia == 0){
                a.transform.SetParent(grupos[0].transform);
            }else if(_quantia == 1){
                a.transform.SetParent(grupos[1].transform);
            }else if(_quantia == 2){
                a.transform.SetParent(grupos[2].transform);
            }
        }
    }

    public void SelecionaSimbulo(GameObject esse){
        if(selecionados < 2){
            simboloSelecionado.Add(esse);
            selecionados ++;
            if(selecionados >= 2){
                foreach (GameObject item in simboloSelecionado)
                {
                    foreach (GameObject opa in SinaisSimplesComfirmado)
                    {
                        if(opa.name == item.name){
                            abacate++;
                        }
                    }
                }
                if(abacate >= simboloSelecionado.Count){
                    vitoria = true;
                }
            }else{
                abacate = 0;
            }
        }
    }
    public void DesSelecionaSimbulo(GameObject esse){
        if(selecionados > 0){
            simboloSelecionado.Remove(esse);
            selecionados --;
            abacate = 0;
        }
    }
}
