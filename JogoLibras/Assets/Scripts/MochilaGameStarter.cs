using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MochilaGameStarter : MonoBehaviour
{
    [SerializeField] public List<GameObject> packs;
    [Header("Tempo Total de Jogo")]
    public int Tempo;
    [Header("Tempo para Perder Estrela")]
    // public int dificuldade;
    public int TempoPerdeuUmaEstrela;
    public int TempoPerdeuDuasEstrelas;
    private GameObject Level;

    [Header("Telas")]
    public GameObject telaescolha;
    public GameObject telatimeup;
    public GameObject telaganhou;
    public Text Estrelas;

    [HideInInspector] public bool ingame;
    private bool Ganhou;
    private bool Perdeu;
    private int nivel;
    private ItemSelector controlador;


  private bool _start;
    private GameDefiner _definer;
    




    void Start()
    {
        Estrelas.text = string.Format ("3 Estrelas");
        controlador = FindObjectOfType<ItemSelector>();

        _definer = FindObjectOfType<GameDefiner>();

        if (_definer.pack == 0)
            return;
        else
           Level = Instantiate(packs[_definer.pack - 1]);

        nivel = PlayerPrefs.GetInt(SceneManager.GetActiveScene().name + _definer.Dificuldade_do_Minigame + _definer.pack);
        Debug.Log(nivel);

        controlador.Comeca();
      

    }

    void Update()
    {
        
        if (!ingame)
        {
            this.GetComponent<Timer>().timerIsRunning = false;
            if (!Perdeu)
            {
                telaescolha.SetActive(true);
                ComecaJogo();
            }

            if (Ganhou)
            {
                telaescolha.SetActive(false);
            }
            else
                if (!Perdeu)
            {
                telaescolha.SetActive(true);
                ComecaJogo();
            }

            
        


        }
        else
        {
            this.GetComponent<Timer>().timerIsRunning = true;
            if (PlayerPrefs.GetInt(SceneManager.GetActiveScene().name + _definer.Dificuldade_do_Minigame + _definer.pack) == 3)
            { _definer.QuantiaEstrela = 3; }
            else
            {

                if (GetComponent<Timer>().timeRemaining > TempoPerdeuUmaEstrela)
                {
                    _definer.QuantiaEstrela = 3;
                    Estrelas.text = string.Format("3 Estrelas");
                }

                if (GetComponent<Timer>().timeRemaining > TempoPerdeuDuasEstrelas && GetComponent<Timer>().timeRemaining < TempoPerdeuUmaEstrela)
                {
                    Estrelas.text = string.Format("2 Estrelas");
                    _definer.QuantiaEstrela = 2;
                }

                if (GetComponent<Timer>().timeRemaining < TempoPerdeuDuasEstrelas && GetComponent<Timer>().timeRemaining != 0)
                {
                    Estrelas.text = string.Format("1 Estrela");
                    _definer.QuantiaEstrela = 1;
                }
                if (GetComponent<Timer>().timeRemaining < 0.05f)
                {
                    Estrelas.text = string.Format("0 Estrelas");
                    _definer.QuantiaEstrela = 0;
                }
            }
        }
    

        if (ingame && controlador.victory == true) 
        {

            ganhou();
        }


        if (ingame && GetComponent<Timer>().perdeu == true)
        {
            perdeu();
        }

    }

    public void ComecaJogo()
    {
        if (_start)
        {
            this.GetComponent<Timer>().timeRemaining = Tempo;
            telaganhou.SetActive(false);
            telatimeup.SetActive(false);
            telaescolha.SetActive(false);
            Level.SetActive(true);
            this.GetComponent<Timer>().enabled = true;
            this.GetComponent<Timer>().timerIsRunning = true;
            
            ingame = true;
            Perdeu = false;
            Ganhou = false;
            controlador.Comecajogo();
        }



    }
    void perdeu()
    {
        Perdeu = true;
        telatimeup.SetActive(true);
        telaescolha.SetActive(false);
        Level.SetActive(false);
      //  dificuldade = 0;



    }

    void ganhou()
    {
        if (!Ganhou)
        {
            _definer.ganhou();
        }
        Ganhou = true;

        // --- SOM VITORIA
        telatimeup.SetActive(false);
        telaescolha.SetActive(false);
        telaganhou.SetActive(true);
        Level.SetActive(false);
        this.GetComponent<Timer>().timerIsRunning = false;

        //  dificuldade = 0;

    }


    public void teladeescolha()
    {
        Ganhou = false;
        _start = false;
        ingame = false;
        Level.SetActive(false);
        telaescolha.SetActive(true);
        telaganhou.SetActive(false);
        controlador.Restart();


    }

    public void inicia()
    {
        _start = true;
    }


}
