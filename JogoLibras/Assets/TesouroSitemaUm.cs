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

    private int _pack, _quantia, _dificuldade,_etapa;
    private GameDefiner definer;
    [Header("Palavras")]
    [SerializeField]private GameObject[] Packs;
    [SerializeField]private List<GameObject> posicoes = new List<GameObject>();
    [SerializeField]private List<Sprite> ItensDeSala= new List<Sprite>();
    [SerializeField]private List<Sprite> ItensDoAluno= new List<Sprite>();
    [SerializeField]private int[] Quantias;
    [SerializeField]private int[] Tempos;
    [SerializeField]private GameObject Mostruario;
    [SerializeField]private Text Palavra;
    [SerializeField]private GameObject WinScreen;
    [SerializeField]private GameObject LoseScreen;
    [SerializeField]private GameObject Acerto, erro;
    [SerializeField]private string[] Compostospack1;
    [SerializeField]private string[] Compostospack2;
    private List<GameObject> ListaDePalavras = new List<GameObject>();
    private List<GameObject> ListaDePalavrasSelecionadas = new List<GameObject>();
    private List<Sprite> ListaDeitens = new List<Sprite>();
    private int PalavraAtual;
    private bool composta;
    [SerializeField]private float TempoCompos;
    private float tempoCo;
    private string compostaAtual;
    private int qual;
    [SerializeField]private Sprite[] estojo;
    [SerializeField]private Sprite[] tinta;
    [SerializeField]private Sprite[] lousa;
    [SerializeField]private Sprite[] armario;
    [SerializeField]private Sprite[] lixeira;
    public void comeca(){
        definer = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameDefiner>();
        _pack = definer.pack;
        _dificuldade = definer.Dificuldade;
        _quantia = definer.Quantia;
        _etapa= definer.Etapa;

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
        if(composta==true){
            if(tempoCo<Time.time){
                if(_pack==0){
                    if(compostaAtual == Compostospack1[0]){
                        Mostruario.GetComponent<Image>().sprite= estojo[qual];
                    }else if(compostaAtual == Compostospack1[1]){
                        Mostruario.GetComponent<Image>().sprite= tinta[qual];
                    }
                }else if(_pack ==1){
                    if(compostaAtual == Compostospack2[0]){
                        Mostruario.GetComponent<Image>().sprite= armario[qual];
                    }else if(compostaAtual == Compostospack2[1]){
                        Mostruario.GetComponent<Image>().sprite= lousa[qual];
                    }else if(compostaAtual == Compostospack2[2]){
                        Mostruario.GetComponent<Image>().sprite= lixeira[qual];
                    }
                }
                if(qual== 0){
                    qual = 1;
                }else{
                    qual =0;
                }
                tempoCo = Time.time +TempoCompos;
            }
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
            int r = Random.Range(0, posicoes.Count);
            if(ListaDePalavras[i]!=null &&posicoes[r]!=null){
                ListaDePalavras[i].transform.position = posicoes[r].transform.position;

                posicoes.Remove(posicoes[r]);
            }
            
        }
    }
    private void ApareceProximaPalavra(){
        string a= "";
        composta = false;
        if(_pack == 0){
            Mostruario.GetComponent<Image>().sprite = ListaDeitens[PalavraAtual];
            if(_etapa == 0){
                a = ListaDeitens[PalavraAtual].name;
                Palavra.text = a;
            }else{
                a = ListaDeitens[PalavraAtual].name;
                Palavra.text = "";
            }
            foreach (string b in Compostospack1)
            {   
                if(b == a){
                    composta = true;
                    qual =0;
                    compostaAtual= b;
                }
            }
        }else if(_pack == 1){
            Mostruario.GetComponent<Image>().sprite = ListaDeitens[PalavraAtual];
            if(_etapa == 0){
                a = ListaDeitens[PalavraAtual].name;
                Palavra.text = a;
            }else{
                a = ListaDeitens[PalavraAtual].name;
                Palavra.text = "";
            }
            foreach (string b in Compostospack2)
            {   
                if(b == a){
                    composta = true;
                    qual =0;
                    compostaAtual= b;
                }
            }
        }
    }

    private void IniciaTime(){
        GetComponent<Timer>().timeRemaining = Tempos[_dificuldade];
        GetComponent<Timer>().timerIsRunning = true;
    }

    public void Apertou(GameObject d){
        Acerto.GetComponent<Animator>().SetTrigger("desativo");
        erro.GetComponent<Animator>().SetTrigger("desativo");
        if(d.name == ListaDePalavrasSelecionadas[PalavraAtual].name){
            Acerto.transform.position = d.transform.position;
            Acerto.GetComponent<Animator>().SetTrigger("ativo");
            PalavraAtual++;
            if(PalavraAtual >= ListaDePalavrasSelecionadas.Count){
                WinScreen.SetActive(true);
            }else{
                ApareceProximaPalavra();
            }
        }else{
            erro.transform.position = d.transform.position;
            erro.GetComponent<Animator>().SetTrigger("ativo");
        }
    }
}
