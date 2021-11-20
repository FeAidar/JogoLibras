using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    [SerializeField]private GameObject[] efeitosAcerto;
    [SerializeField]private GameObject[] efeitosErro;
    [SerializeField]private float[] tempos;
    [SerializeField] private GameObject telaVitoria, teladerrota;
    [SerializeField]private GameObject countdown;
    
    private List<GameObject> CartasSelecionadasDoPack = new List<GameObject>();
    private List<GameObject> CartasSelecionadas = new List<GameObject>();
    private List<GameObject> CartasClicadas = new List<GameObject>();
    private List<GameObject> CartasPareadas = new List<GameObject>();
    private GameObject _Definer;
    private int _pack, _dificuldade, _quantia, _Etapa;
    public bool ganhou;
    public AudioSource Acertou2;
    public AudioSource Errou2;
    private bool umavez = true, mostrado=false;
    public void começa()
    {
        if(umavez){
            _Definer = GameObject.FindGameObjectWithTag("GameController");
            if(GameObject.FindGameObjectWithTag("GameController") != null){
                if(_Definer.GetComponent<GameDefiner>() != null){
                    _dificuldade = _Definer.GetComponent<GameDefiner>().Dificuldade;
                    _pack = _Definer.GetComponent<GameDefiner>().pack;
                    _quantia = _Definer.GetComponent<GameDefiner>().Quantia;
                    _Etapa =_Definer.GetComponent<GameDefiner>().Etapa;
                }
            }


            Grids[0].SetActive(false);
            Grids[1].SetActive(false);
            Grids[2].SetActive(false);


            EscolhePack();
            ColocaNoGrid();
            TempoAntes();
            umavez = false;
        }
    }
    private void TempoAntes(){
        StartCoroutine(vira());
    }
    IEnumerator vira(){
        yield return new WaitForSeconds(0.1f);
            foreach(GameObject f in CartasSelecionadas){
                f.GetComponent<Carta>().mostra();
            }
        yield return new WaitForSeconds(2f);
            countdown.SetActive(true);
            countdown.GetComponent<CountDown>().denovo();
        yield return new WaitForSeconds(4.1f);
            foreach(GameObject f in CartasSelecionadas){
                f.GetComponent<Carta>().verso();
            }
            Comecatempo();
            mostrado=true;
            Destroy(countdown);
    }
    private void Update(){
        if (this.GetComponent<Timer>().perdeu == true)
        {
            teladerrota.SetActive(true);
        }
        else StarCounter();
    }
    private void Comecatempo(){
        this.GetComponent<Timer>().timeRemaining = tempos[_dificuldade];
        this.GetComponent<Timer>().tempo = tempos[_dificuldade];
        this.GetComponent<Timer>().timerIsRunning= true;
    }


    private void EscolhePack(){
        GameObject pack = Instantiate(PackDePalavras[_pack], transform.position, Quaternion.identity);
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
            Debug.Log("bbbbb");
            GameObject b = Instantiate(CartasSelecionadasDoPack[i],transform.position, Quaternion.identity);
            CartasSelecionadas.Add(CartasSelecionadasDoPack[i]);
            CartasSelecionadas.Add(b);
            if(_Etapa == 1){
                Debug.Log("aaaaaaaaa");
                b.GetComponent<Carta>().essa = true;
            }else if(_Etapa == 2){
                b.GetComponent<Carta>().essa = true;
                CartasSelecionadasDoPack[i].GetComponent<Carta>().EtapaSemPalavra = true;
            }
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
        if(mostrado == true){
            efeitosAcerto[0].transform.GetComponent<Animator>().SetTrigger("desativo");
            efeitosAcerto[1].transform.GetComponent<Animator>().SetTrigger("desativo");
            if(CartasClicadas.Count < 2){
                if(esse.GetComponent<Carta>().par == false){
                    CartasClicadas.Add(esse);
                    esse.GetComponent<Carta>().frente();
                }
                if(CartasClicadas.Count == 2){
                    if(CartasClicadas[0].GetComponent<Carta>().Significado == CartasClicadas[1].GetComponent<Carta>().Significado){
                        CartasClicadas[0].GetComponent<Carta>().par = true;
                        efeitosAcerto[0].transform.position = CartasClicadas[0].transform.position;
                        efeitosAcerto[0].transform.GetComponent<Animator>().SetTrigger("ativo");
                        CartasClicadas[1].GetComponent<Carta>().par = true;
                        efeitosAcerto[1].transform.position = CartasClicadas[1].transform.position;
                        efeitosAcerto[1].transform.GetComponent<Animator>().SetTrigger("ativo");
                        CartasPareadas.Add(CartasClicadas[0]);
                        CartasPareadas.Add(CartasClicadas[1]);
                        Acertou2.Play();

                        if(CartasPareadas.Count == CartasSelecionadas.Count){
                            _Definer.GetComponent<GameDefiner>().ganhou();
                            telaVitoria.SetActive(true);
                            //Coloquei aqui a chamada de pontuação do Definer
                            _Definer.GetComponent<GameDefiner>().ganhou();
                            //SOM DE GANHOU TODAS

                        }
                        CartasClicadas.Clear();
                    }else{
                        deErro();
                        Errou2.Play();
                    }
                }
            }else{
                DesselecionaTodas();
                Errou2.Play();
            }
        }
    }

    public void CartaDesselecionada(GameObject esse){
        esse.GetComponent<Carta>().verso();
        CartasClicadas.Remove(esse);
    }

    private void DesselecionaTodas(){
        int d=0;
        efeitosErro[0].GetComponent<Animator>().SetTrigger("desativo");
        efeitosErro[1].GetComponent<Animator>().SetTrigger("desativo");
        efeitosErro[2].GetComponent<Animator>().SetTrigger("desativo");
        foreach (GameObject b in CartasClicadas)
        {
            efeitosErro[d].transform.position = b.transform.position;
            efeitosErro[d].GetComponent<Animator>().SetTrigger("ativo");
            b.GetComponent<Carta>().verso();
            d++;
        }
        CartasClicadas.Clear();
    }
    private void deErro(){
        int d=0;
        efeitosErro[0].GetComponent<Animator>().SetTrigger("desativo");
        efeitosErro[1].GetComponent<Animator>().SetTrigger("desativo");
        efeitosErro[2].GetComponent<Animator>().SetTrigger("desativo");
        foreach (GameObject b in CartasClicadas)
        {
            efeitosErro[d].transform.position = b.transform.position;
            efeitosErro[d].GetComponent<Animator>().SetTrigger("ativo");
            d++;
        }
    }
    void StarCounter()
    {
        if(mostrado==true){
            if (PlayerPrefs.GetInt(SceneManager.GetActiveScene().name + _Definer.GetComponent<GameDefiner>().Dificuldade_do_Minigame + _Definer.GetComponent<GameDefiner>().pack) == 3)
            { _Definer.GetComponent<GameDefiner>().QuantiaEstrela = 3; }
            else
            {

                if (GetComponent<Timer>().timeRemaining > _Definer.GetComponent<GameDefiner>().TempoTresEstrelas)
                {
                    _Definer.GetComponent<GameDefiner>().QuantiaEstrela = 3;

                }

                if (GetComponent<Timer>().timeRemaining > _Definer.GetComponent<GameDefiner>().TempoDuasEstrelas && GetComponent<Timer>().timeRemaining < _Definer.GetComponent<GameDefiner>().TempoUmaEstrela)
                {

                    _Definer.GetComponent<GameDefiner>().QuantiaEstrela = 2;
                }

                if (GetComponent<Timer>().timeRemaining < _Definer.GetComponent<GameDefiner>().TempoDuasEstrelas && GetComponent<Timer>().timeRemaining != 0)
                {

                    _Definer.GetComponent<GameDefiner>().QuantiaEstrela = 1;
                }
                if (GetComponent<Timer>().timeRemaining < 0.05f)
                {

                    _Definer.GetComponent<GameDefiner>().QuantiaEstrela = 0;
                }
            }
        }
    }
}
