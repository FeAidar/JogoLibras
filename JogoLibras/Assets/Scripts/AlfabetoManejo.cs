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

    public bool EscreveNome;
    [SerializeField]private List<GameObject> letras = new List<GameObject>();
    [SerializeField]private List<GameObject> PackDePalavras = new List<GameObject>();
    [SerializeField]private GameObject espaço, espaços;
    [SerializeField] private GameObject espaçosnome;
    [SerializeField]private GameObject posipalavra;
    [SerializeField]private float[] tempos;
    [SerializeField]private GameObject telavitoria;
    private List<GameObject> PackSelecionado = new List<GameObject>();
    private GameObject palavraConfirma;
    private List<char> LetrasCertas = new List<char>();
    private List<GameObject> LetrasSelecionadas = new List<GameObject>();
    private List<GameObject> espacosCertos = new List<GameObject>();
    private List<GameObject> espacosnomememorizado = new List<GameObject>();
    private GameObject Definer;
    private int _Dificudade, _Pack, _quantia;
    private string palavraSelecionada;
    private int quantidadeLetras;
    public bool ganhou;
    int quantas;
    public string nome;
    public TMPro.TextMeshProUGUI textoconfirmacao;
    public Button BotaoOK;
    public GameObject telavitoria2;
    private GameObject espaco;
    public GameObject NomedaAlana;
    private void Update(){
        if (EscreveNome)
        {
            BTM_Entername();

            if (nome == "")
                BotaoOK.interactable = false;
            else if (nome == null)
                BotaoOK.interactable = false;
            else
                BotaoOK.interactable = true;
        }



    }
    public void Start(){
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
        _Pack = 0;

        if (!EscreveNome)
        {
            SelecionaPalavra();
            EspacosAdd();
            quantidadeLetras = LetrasCertas.Count;
        }
        else quantidadeLetras = 8;

       // Comecatempo();
    }

    //private void Comecatempo(){
 //       this.GetComponent<Timer>().timeRemaining = tempos[_Dificudade];
   //     this.GetComponent<Timer>().tempo = tempos[_Dificudade];
  //      this.GetComponent<Timer>().timerIsRunning= true;
 //       Debug.Log(this.GetComponent<Timer>().timeRemaining);
//    }
    private void SelecionaPalavra(){
        LetrasCertas.Clear();
        GameObject Packconfima = Instantiate(PackDePalavras[_Pack], new Vector3(1000f, 1000f,0f), Quaternion.identity);
        int a = Packconfima.transform.childCount;
        for (int i = 0; i < a; i++)
        {
            PackSelecionado.Add(Packconfima.transform.GetChild(i).gameObject);
        }
        int b = Random.Range(0, PackSelecionado.Count);
        palavraConfirma = PackSelecionado[b];
        palavraConfirma.transform.position = posipalavra.transform.position;
        if(_Pack == 0)
         palavraConfirma.GetComponent<palavra>().Palavra = PlayerPrefs.GetString("Nome"); 

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

            if (LetrasSelecionadas.Count < quantidadeLetras)

            {
            if (EscreveNome)
            {
                GameObject espaco = Instantiate(espaço, transform.position, Quaternion.identity);
                espacosCertos.Add(espaco);
                espaco.transform.SetParent(espaços.transform);
                espaco.transform.localScale = new Vector3(1.5f, 1.5f, 1f);
            }

            quantas= 0;
            LetrasSelecionadas.Add(Instantiate(letras[numero], espacosCertos[LetrasSelecionadas.Count].transform.position, Quaternion.identity));
                LetrasSelecionadas[LetrasSelecionadas.Count - 1].transform.SetParent(espacosCertos[LetrasSelecionadas.Count - 1].transform);
                LetrasSelecionadas[LetrasSelecionadas.Count - 1].transform.localScale = new Vector3(1f, 1f, 1f);
                if (LetrasSelecionadas.Count == quantidadeLetras)
                {
                    for (int i = 0; i < quantidadeLetras; i++)
                    {
                        if (LetrasSelecionadas[i].GetComponent<BotaoLetra>().letra == LetrasCertas[i])
                        {
                            quantas++;
                        }
                    }
                }
            }
        


        if(quantas == quantidadeLetras){
            telavitoria.SetActive(true);
            
            //Coloquei aqui a chamada de pontuação do Definer
            // Definer.GetComponent<GameDefiner>().ganhou();
        }
    }

    public void BTM_REMOVE()
    {
       if (EscreveNome)
        {
            if (espacosCertos.Count != 0)
            {
                Destroy(espacosCertos[espacosCertos.Count - 1]);
                espacosCertos.Remove(espacosCertos[espacosCertos.Count - 1]);
            }

        }


        if (!EscreveNome)
        {

            quantas = 0;
            if (LetrasSelecionadas[LetrasSelecionadas.Count - 1].GetComponent<BotaoLetra>().letra == LetrasCertas[LetrasSelecionadas.Count - 1])
          {

               quantas--;

          }
          
            

            }

        if (LetrasSelecionadas.Count != 0)
        {
            Destroy(LetrasSelecionadas[LetrasSelecionadas.Count - 1]);
            LetrasSelecionadas.Remove(LetrasSelecionadas[LetrasSelecionadas.Count - 1]);
        }

    }

    public void BTM_clear(){
        int a = LetrasSelecionadas.Count;
        quantas=0;
        foreach (GameObject b in LetrasSelecionadas)
        {
            Destroy(b);
        }
        LetrasSelecionadas.Clear();
        if (EscreveNome)
        {
            foreach (GameObject b in espacosCertos)
            {
                Destroy(b);
            }
            espacosCertos.Clear();
        }
    }

    public void BTM_Entername()
    {
        nome = "";
        foreach (GameObject s in LetrasSelecionadas)
        {
            nome = nome + s.GetComponent<BotaoLetra>().letra;
            

            textoconfirmacao.text = "Seu nome é " + nome+"?";
            
        }

    }

    public void Aprendenome()
    {
        PlayerPrefs.SetString ("Nome", nome);

            espaco = Instantiate(espaços, espaços.transform.position, Quaternion.identity);
                        espaco.transform.SetParent(espaçosnome.transform);
        espaco.GetComponent<RectTransform>().anchorMin = espaços.GetComponent<RectTransform>().anchorMin;
        espaco.GetComponent<RectTransform>().anchorMax = espaços.GetComponent<RectTransform>().anchorMax;
        espaco.GetComponent<RectTransform>().anchoredPosition = espaços.GetComponent<RectTransform>().anchoredPosition + new Vector2 (0, +200);
        espaco.GetComponent<RectTransform>().sizeDelta = espaços.GetComponent<RectTransform>().sizeDelta;
        espaco.GetComponent<RectTransform>().localScale = espaços.GetComponent<RectTransform>().localScale;
        BTM_clear();
        EscreveNome = false;
        SelecionaPalavra();
        EspacosAdd();
        quantidadeLetras = LetrasCertas.Count;
        

    }

    public void trocasimbolos()
    {

        ArrayList A = new ArrayList ( GameObject.FindGameObjectsWithTag("Alfabeto"));
        Debug.Log(A.Count);

        foreach (GameObject s in A)
        {
                        s.GetComponent<BotaoLetra>().EntraLetra();
        }
        
    }

    public void Restart()
    {
        StartCoroutine("Allana");


    }

    IEnumerator Allana()
    {


        BTM_clear();
        Destroy(espaco);
        _Pack = 1;
        yield return new WaitForSeconds(0.1f);
         quantidadeLetras = 0;
        foreach (GameObject b in espacosCertos)
        {
            Destroy(b);
        }
        LetrasCertas.Clear();
        palavraSelecionada = null;
        espacosCertos.Clear();
        LetrasSelecionadas.Clear();
        quantas = 0;

        yield return new WaitForSeconds(0.1f);
       SelecionaPalavra();
        Debug.Log(palavraSelecionada);
            yield return new WaitForSeconds(0.1f);
        quantidadeLetras = LetrasCertas.Count;
        
        yield return new WaitForSeconds(0.1f);
        EspacosAdd();
        NomedaAlana.SetActive(true);
        Debug.Log(quantas + " letras atuais");
        Debug.Log(quantidadeLetras + " letras totais");
        telavitoria = telavitoria2;

    }

    public void completoututorial()
    {
        PlayerPrefs.SetInt("Introducao", 1);
    }
}
