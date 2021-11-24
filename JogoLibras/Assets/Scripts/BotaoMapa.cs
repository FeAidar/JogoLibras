using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BotaoMapa : MonoBehaviour
{
    private Posicionaplayer Controlador;
    [Header("Posição do jogo no mapa")]
    public int Posicao;


    [Header("Descrição do Minigame e nome do mapa")]
    [SerializeField] public string Texto;
    [SerializeField] public string Mapa;

    [Header("Configurações do Minigame")]
    public int Dificuldade;
    public int Pack;
    public int Quantia;
    public bool tutorial;
    

    [Header("Se o minigame se repete no pack, troque o n�mero da vers�o")]
    public int VersaoDoMinigame;


    [Header("Tempo Total de Jogo")]
    public int Tempo;

    [Header("Tempo de Estrelas")]
    public int TempoTresEstrelas;
    public int TempoDuasEstrelas;
    public int TempoUmaEstrela;

    [Header("Se é um jogo que perde ou ganha estrelas")]
    public bool PerdeEstrelas;

    private GameDefiner _definer;
    private GameObject _botao;
    private GameObject _descricao;
    private Text textodescricao;
    private GameObject _estrela1;
    private GameObject _estrela2;
    private GameObject _estrela3;


    void Start()
    {
        Controlador = FindObjectOfType<Posicionaplayer>();
        _definer = FindObjectOfType<GameDefiner>();
        _descricao = GameObject.Find("Descricao");
        textodescricao = _descricao.GetComponent<Text>();
        _botao = GameObject.Find("Jogar");
        _estrela1 = GameObject.Find("Estrela 1");
        _estrela2 = GameObject.Find("Estrela 2");
        _estrela3 = GameObject.Find("Estrela 3");
        if(PlayerPrefs.GetInt("fasenomapa") == Posicao)
        {
            apertou();
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void apertou()
    {
        _botao.SetActive(true);
        _estrela1.SetActive(true);
        _estrela2.SetActive(true);
        _estrela3.SetActive(true);
         Controlador.fase = Posicao;
        _botao.SetActive(true);
        textodescricao.text = Texto;
        _definer.Dificuldade = Dificuldade;
        _definer.pack = Pack;
        _definer.Quantia = Quantia;
        _definer.Etapa = VersaoDoMinigame;
        _definer.Tempo = Tempo;
        _definer.TempoTresEstrelas = TempoTresEstrelas;
        _definer.TempoDuasEstrelas = TempoDuasEstrelas;
        _definer.TempoUmaEstrela = TempoUmaEstrela;
        _definer.PerdeEstrelas = PerdeEstrelas;
        _definer.dialogo = tutorial;
        _botao.GetComponent<teleport>().level =Mapa;
        PlayerPrefs.SetInt ("fasenomapa", Posicao);

        string premio = (Mapa + ".Dificuldade" + Dificuldade + ".Pack" + Pack + ".Quantia" + Quantia + ".Etapa" + VersaoDoMinigame); ;

        if (PlayerPrefs.GetInt(premio) == 1)
        {
            Image image;
            image = _estrela1.GetComponent<Image>();
            var tempColor = image.color;
            tempColor.a = 1f;
            image.color = tempColor;

            Image image2;
            image2 = _estrela2.GetComponent<Image>();
            var tempColor2 = image2.color;
            tempColor2.a = 0f;
            image2.color = tempColor2;

            Image image3;
            image3 = _estrela3.GetComponent<Image>();
            var tempColor3 = image3.color;
            tempColor3.a = 0f;
            image3.color = tempColor3;
           // Debug.Log((Mapa + Dificuldade));
          //  Debug.Log(PlayerPrefs.GetInt(Mapa + Dificuldade));

        }

        if (PlayerPrefs.GetInt(premio) == 2)
        {
            Image image;
            image = _estrela1.GetComponent<Image>();
            var tempColor = image.color;
            tempColor.a = 1f;
            image.color = tempColor;

            Image image2;
            image2 = _estrela2.GetComponent<Image>();
            var tempColor2 = image2.color;
            tempColor2.a = 1f;
            image2.color = tempColor2;

            Image image3;
            image3 = _estrela3.GetComponent<Image>();
            var tempColor3 = image3.color;
            tempColor3.a = 0f;
            image3.color = tempColor3;

        }

        if (PlayerPrefs.GetInt(premio) >= 3)
        {
            Image image;
            image = _estrela1.GetComponent<Image>();
            var tempColor = image.color;
            tempColor.a = 1f;
            image.color = tempColor;

            Image image2;
            image2 = _estrela2.GetComponent<Image>();
            var tempColor2 = image2.color;
            tempColor2.a = 1f;
            image2.color = tempColor2;

            Image image3;
            image3 = _estrela3.GetComponent<Image>();
            var tempColor3 = image3.color;
            tempColor3.a = 1f;
            image3.color = tempColor3;
        }

        if (PlayerPrefs.GetInt(premio) == 0)
        {
            Image image;
            image = _estrela1.GetComponent<Image>();
            var tempColor = image.color;
            tempColor.a = 0f;
            image.color = tempColor;

            Image image2;
            image2 = _estrela2.GetComponent<Image>();
            var tempColor2 = image2.color;
            tempColor2.a = 0f;
            image2.color = tempColor2;

            Image image3;
            image3 = _estrela3.GetComponent<Image>();
            var tempColor3 = image3.color;
            tempColor3.a = 0f;
            image3.color = tempColor3;
        }
    }
}
