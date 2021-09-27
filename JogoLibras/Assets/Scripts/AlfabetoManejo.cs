using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AlfabetoManejo : MonoBehaviour
{
    /*
        1. selecionar uma palavra
        2. separar essa palavras em letras
        3. separar os espaços necessarios para a quantidade de letras
        4. função para adcionar as letras nos espaços
        5. botão de remover a ultima letra selecionadas
        6. botão para remover todas as letras selecionadas
    */


    [SerializeField]private List<GameObject> letras = new List<GameObject>();
    [SerializeField]private List<GameObject> PackDePalavras = new List<GameObject>();
    [SerializeField]private GameObject espaço, espaços;
    [SerializeField]private GameObject posipalavra;
    [SerializeField]private float[] tempos;
    [SerializeField]private GameObject telavitoria;
    [SerializeField]private GameObject telaDerrota;
    private List<GameObject> PackSelecionado = new List<GameObject>();
    private GameObject palavraConfirma;
    private List<char> LetrasCertas = new List<char>();
    private List<GameObject> LetrasSelecionadas = new List<GameObject>();
    private List<GameObject> espacosCertos = new List<GameObject>();
    private GameObject Definer;
    private int _Dificudade, _Pack, _quantia;
    private string palavraSelecionada;
    private int quantidadeLetras;
    public bool ganhou;
    int quantas;
    private void Update(){
        if( this.GetComponent<Timer>().perdeu == true){
            telaDerrota.SetActive(true);
        }
    }
    public void comeca(){
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
        SelecionaPalavra();
        EspacosAdd();
        quantidadeLetras = LetrasCertas.Count;
        Comecatempo();
    }

    private void Comecatempo(){
        this.GetComponent<Timer>().timeRemaining = tempos[_Dificudade];
        this.GetComponent<Timer>().tempo = tempos[_Dificudade];
        this.GetComponent<Timer>().timerIsRunning= true;
        Debug.Log(this.GetComponent<Timer>().timeRemaining);
    }
    private void SelecionaPalavra(){
        GameObject Packconfima = Instantiate(PackDePalavras[_Pack], new Vector3(1000f, 1000f,0f), Quaternion.identity);
        int a = Packconfima.transform.childCount;
        for (int i = 0; i < a; i++)
        {
            PackSelecionado.Add(Packconfima.transform.GetChild(i).gameObject);
        }
        int b = Random.Range(0, PackSelecionado.Count);
        palavraConfirma = PackSelecionado[b];
        palavraConfirma.transform.position = posipalavra.transform.position;
        palavraSelecionada = palavraConfirma.GetComponent<palavra>().Palavra;
        foreach (char s in palavraSelecionada)
        {
            LetrasCertas.Add(s);
        }
    }

    private void EspacosAdd(){
        int a = LetrasCertas.Count;
        for (int i = 0; i < a; i++)
        {
            GameObject espaco = Instantiate(espaço, transform.position, Quaternion.identity);
            espacosCertos.Add(espaco);
            espaco.transform.SetParent(espaços.transform);
            espaco.transform.localScale = new Vector3(1.5f,1.5f,1f);
        }
    }

    public void BTM_add(int numero){
        if(LetrasSelecionadas.Count < quantidadeLetras){
            LetrasSelecionadas.Add(Instantiate(letras[numero],espacosCertos[LetrasSelecionadas.Count].transform.position, Quaternion.identity));
            LetrasSelecionadas[LetrasSelecionadas.Count -1].transform.SetParent(espacosCertos[LetrasSelecionadas.Count -1 ].transform);
            LetrasSelecionadas[LetrasSelecionadas.Count -1].transform.localScale = new Vector3(1f, 1f, 1f);
            if(LetrasSelecionadas.Count == quantidadeLetras){
                for (int i = 0; i < quantidadeLetras; i++)
                {
                    if(LetrasSelecionadas[i].GetComponent<BotaoLetra>().letra == LetrasCertas[i]){
                        quantas++;
                    }
                }
            }
        }
        if(quantas == quantidadeLetras){
            telavitoria.SetActive(true);
            //Coloquei aqui a chamada de pontuação do Definer
            Definer.GetComponent<GameDefiner>().ganhou();
        }
    }

    public void BTM_REMOVE(){
        Destroy(LetrasSelecionadas[LetrasSelecionadas.Count -1]);
        LetrasSelecionadas.Remove(LetrasSelecionadas[LetrasSelecionadas.Count -1]);
    }

    public void BTM_clear(){
        int a = LetrasSelecionadas.Count;
        foreach (GameObject b in LetrasSelecionadas)
        {
            Destroy(b);
        }
        LetrasSelecionadas.Clear();
    }
}
