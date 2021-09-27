using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CartaManege : MonoBehaviour
{
    /*
        1.escolher pack 
        2.gerar as cartas que precisa 
        3.colocar as cartas no grid da dificuldade 
        4.função para adicionar a carta
        5.função para remover a carta
        6.função para remover todas as cartas
    */
    [SerializeField]private List<GameObject> PackDePalavras = new List<GameObject>();
    [SerializeField]private List<GameObject> Grids = new List<GameObject>();
    [SerializeField]private int[] QuantiaJogadas;
    [SerializeField]private float[] tempos;
    [SerializeField]private Text Jogadas;
    [SerializeField] private GameObject telaVitoria, teladerrota;
    private List<GameObject> CartasSelecionadasDoPack = new List<GameObject>();
    private List<GameObject> CartasSelecionadas = new List<GameObject>();
    private List<GameObject> CartasClicadas = new List<GameObject>();
    private List<GameObject> CartasPareadas = new List<GameObject>();
    private GameObject _Definer;
    private int _pack, _dificuldade, _quantia;
    private int JogadasRestantes;
    public bool ganhou;
    public AudioSource Acertou2;
    public void comeca()
    {
        _Definer = GameObject.FindGameObjectWithTag("GameController");
        if(GameObject.FindGameObjectWithTag("GameController") != null){
            if(_Definer.GetComponent<GameDefiner>() != null){
                _dificuldade = _Definer.GetComponent<GameDefiner>().Dificuldade;
                _pack = _Definer.GetComponent<GameDefiner>().pack;
                _quantia = _Definer.GetComponent<GameDefiner>().Quantia;
            }
        }


        Grids[0].SetActive(false);
        Grids[1].SetActive(false);
        Grids[2].SetActive(false);

        JogadasRestantes = QuantiaJogadas[_dificuldade];

        EscolhePack();
        ColocaNoGrid();
        Comecatempo();
    }
    private void Update(){
        Jogadas.text = ""+JogadasRestantes;
        if( this.GetComponent<Timer>().perdeu == true){
            teladerrota.SetActive(true);
        }
    }
    private void Comecatempo(){
        this.GetComponent<Timer>().timeRemaining = tempos[_dificuldade];
        this.GetComponent<Timer>().tempo = tempos[_dificuldade];
        this.GetComponent<Timer>().timerIsRunning= true;
    }


    private void EscolhePack(){
        int a = Random.Range(0, PackDePalavras.Count);
        GameObject pack = Instantiate(PackDePalavras[a], transform.position, Quaternion.identity);
        int b = pack.transform.childCount;
        for (int i = 0; i < b; i++)
        {
            CartasSelecionadasDoPack.Add(pack.transform.GetChild(i).gameObject);
        }
    }
    private void ColocaNoGrid(){
        reorganizaCartas();
        switch (_quantia)
        {
            case 0:
                Grids[0].SetActive(true);
                selecionacartas(4);
                reorganizaCartasCertas(Grids[0]);
            break;
            case 1:
                Grids[1].SetActive(true);
                selecionacartas(6);
                reorganizaCartasCertas(Grids[1]);
            break;
            case 2:
                Grids[2].SetActive(true);
                selecionacartas(8);
                reorganizaCartasCertas(Grids[2]);
            break;
        }
    }

    private void reorganizaCartas(){
        for (int i = 0; i < CartasSelecionadasDoPack.Count; i++) {
            GameObject temp = CartasSelecionadasDoPack[i];
            int randomIndex = Random.Range(i, CartasSelecionadasDoPack.Count);
            CartasSelecionadasDoPack[i] = CartasSelecionadasDoPack[randomIndex];
            CartasSelecionadasDoPack[randomIndex] = temp;
        }
    }
    private void selecionacartas(int a){
        for (int i = 0; i < a; i++)
        {
            GameObject b = Instantiate(CartasSelecionadasDoPack[i],transform.position, Quaternion.identity);
            CartasSelecionadas.Add(CartasSelecionadasDoPack[i]);
            CartasSelecionadas.Add(b);
        }
    }
    private void reorganizaCartasCertas(GameObject b){
        for (int i = 0; i < CartasSelecionadas.Count; i++) {
            GameObject temp = CartasSelecionadas[i];
            int randomIndex = Random.Range(i, CartasSelecionadas.Count);
            CartasSelecionadas[i] = CartasSelecionadas[randomIndex];
            CartasSelecionadas[randomIndex] = temp;
        }
        foreach(GameObject a in CartasSelecionadas){
            a.transform.SetParent(b.transform);
            a.transform.localScale = new Vector3(1.25f,1.5f,1.25f);
        }
    }

    public void CartaSelecionada(GameObject esse){
        if(CartasClicadas.Count < 2){
            if(esse.GetComponent<Carta>().par == false){
                CartasClicadas.Add(esse);
                esse.GetComponent<Carta>().frente();
            }
            if(CartasClicadas.Count == 2){
                if(CartasClicadas[0].GetComponent<Carta>().Significado == CartasClicadas[1].GetComponent<Carta>().Significado){
                    CartasClicadas[0].GetComponent<Carta>().par = true;
                    CartasClicadas[1].GetComponent<Carta>().par = true;
                    CartasPareadas.Add(CartasClicadas[0]);
                    CartasPareadas.Add(CartasClicadas[1]);
                    Acertou2.Play();

                    if(CartasPareadas.Count == CartasSelecionadas.Count){
                        telaVitoria.SetActive(true);
                        //Coloquei aqui a chamada de pontuação do Definer
                        _Definer.GetComponent<GameDefiner>().ganhou();
                        //SOM DE GANHOU TODAS

                    }
                    CartasClicadas.Clear();
                }
            }
        }else{
            DesselecionaTodas();
        }
        JogadasRestantes --;
        if(JogadasRestantes == 0){
            teladerrota.SetActive(true);
        }
    }

    public void CartaDesselecionada(GameObject esse){
        esse.GetComponent<Carta>().verso();
        CartasClicadas.Remove(esse);
        JogadasRestantes --;
        if(JogadasRestantes == 0){
            teladerrota.SetActive(true);
        }
    }

    private void DesselecionaTodas(){
        foreach (GameObject b in CartasClicadas)
        {
            b.GetComponent<Carta>().verso();
        }
        CartasClicadas.Clear();
    }
}
