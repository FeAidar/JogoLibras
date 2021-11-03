using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TesouroSitemaUm : MonoBehaviour
{
    /*
        1. definir pack
        2. escolher as palavras
        3. escolher ordem para pedir
        4. aparecer na tela a palavra atual
        5. verificar se o objeto apertado é o certo
    */

    private int _pack, _quantia, _dificuldade;
    private GameDefiner definer;
    [Header("Palavras")]
    [SerializeField]private GameObject[] Packs;
    [SerializeField]private List<GameObject> posicoes = new List<GameObject>();
    [SerializeField]private List<Sprite> ItensDeSala= new List<Sprite>();
    [SerializeField]private List<Sprite> ItensDoAluno= new List<Sprite>();
    [SerializeField]private int[] Quantias;
    [SerializeField]private int[] Tempos;
    [SerializeField]private GameObject Mostruario;
    [SerializeField]private GameObject WinScreen;
    [SerializeField]private GameObject LoseScreen;
    private List<GameObject> ListaDePalavras = new List<GameObject>();
    private List<GameObject> ListaDePalavrasSelecionadas = new List<GameObject>();
    private List<Sprite> ListaDeitens = new List<Sprite>();
    private int PalavraAtual;

    public void comeca(){
        definer = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameDefiner>();
        _pack = definer.pack;
        _dificuldade = definer.Dificuldade;
        _quantia = definer.Quantia;

        DefinePack();
        EscolhePalavras();
        EscolheOrdem();
        ApareceProximaPalavra();
        IniciaTime();
    }
    void Update(){
        if(GetComponent<Timer>().timeRemaining <= 0){
            LoseScreen.SetActive(true);
        }
    }

    private void DefinePack(){
        int a = Packs[_pack].transform.childCount;
        Packs[_pack].SetActive(true);
        for (int i = 0; i < a; i++)
        {
            ListaDePalavras.Add(Packs[_pack].transform.GetChild(i).gameObject);
        }
        if(_pack == 0){
            ColocaNaPosi();
        }
    }
    private void EscolhePalavras(){
        int a = Quantias[_quantia];
        for (int i = 0; i < a; i++)
        {
            int b = Random.Range(0, ListaDePalavras.Count);
            ListaDePalavrasSelecionadas.Add(ListaDePalavras[b]);
            if(_pack == 0){
                ListaDeitens.Add(ItensDoAluno[b]);
                ItensDoAluno.Remove(ItensDoAluno[b]);
            }else if(_pack == 1){
                ListaDeitens.Add(ItensDeSala[b]);
                ItensDeSala.Remove(ItensDeSala[b]);
            }
            ListaDePalavras.Remove(ListaDePalavras[b]);
        }
    }
    private void EscolheOrdem(){
        for (int i = 0; i < ListaDePalavrasSelecionadas.Count; i++) {
            GameObject temp = ListaDePalavrasSelecionadas[i];
            Sprite tempSpri = ListaDeitens[i];
            int randomIndex = Random.Range(i, ListaDePalavrasSelecionadas.Count);
            ListaDePalavrasSelecionadas[i] =ListaDePalavrasSelecionadas[randomIndex];
            ListaDeitens[i] = ListaDeitens[randomIndex];
            ListaDePalavrasSelecionadas[randomIndex] = temp;
            ListaDeitens[randomIndex] = tempSpri;
        }
    }
    private void ColocaNaPosi(){
        int e = ListaDePalavras.Count;
        for (int i = 0; i < e; i++)
        {
            int a = Random.Range(0, posicoes.Count);
            ListaDePalavras[i].transform.position = posicoes[a].transform.position;
            posicoes.Remove(posicoes[a]);
        }
    }
    private void ApareceProximaPalavra(){
        if(_pack == 0){
            Mostruario.GetComponent<Image>().sprite = ItensDoAluno[PalavraAtual];
        }else if(_pack == 1){
            Mostruario.GetComponent<Image>().sprite = ItensDeSala[PalavraAtual];
        }
    }
    private void IniciaTime(){
        GetComponent<Timer>().timeRemaining = Tempos[_dificuldade];
        GetComponent<Timer>().timerIsRunning = true;
    }

    public void Apertou(GameObject d){
        if(d.name == ListaDePalavrasSelecionadas[PalavraAtual].name){
            PalavraAtual++;
            if(PalavraAtual >= ListaDePalavrasSelecionadas.Count){
                WinScreen.SetActive(true);
            }else{
                ApareceProximaPalavra();
            }
        }
    }
}
