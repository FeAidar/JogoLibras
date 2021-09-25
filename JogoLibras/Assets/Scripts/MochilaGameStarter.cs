using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MochilaGameStarter : MonoBehaviour
{
    [SerializeField] public List<GameObject> packs;
    [Header("Níveis de Dificuldade do Minigame")]
    public int dificuldade;
    public int tempo_facil;
    public int tempo_medio;
    public int tempo_dificil;
    private GameObject Level;

    [Header("Telas")]
    public GameObject telaescolha;
    public GameObject telatimeup;
    public GameObject telaganhou;
    [HideInInspector] public bool ingame;
    private bool Ganhou;
    private bool Perdeu;
    private int nivel;
    private ItemSelector controlador;
    [HideInInspector] public int jogandolevel;
    private GameDefiner _definer;
    




    void Start()
    {
       
        controlador = FindObjectOfType<ItemSelector>();
        jogandolevel = 0;
        _definer = FindObjectOfType<GameDefiner>();

        if (_definer.pack == 0)
            return;
        else
           Level = Instantiate(packs[_definer.pack - 1]);

        nivel = PlayerPrefs.GetInt(SceneManager.GetActiveScene().name + _definer.Dificuldade);
        Debug.Log(nivel);

        controlador.Comeca();
      

    }

    void Update()
    {
        _definer.QuantiaEstrela = jogandolevel;

        if (!ingame)
        {
            if (!Perdeu)
            {
                telaescolha.SetActive(true);
                niveis();
            }

            if (Ganhou)
            {
                telaescolha.SetActive(false);
            }
            else
                if (!Perdeu)
            {
                telaescolha.SetActive(true);
                niveis();
            }

            
        


        }
        else
        this.GetComponent<Timer>().timerIsRunning = true;

        if (ingame && controlador.victory == true) 
        {

            ganhou();
        }





        if (dificuldade == 0)
        { ingame = false;
            this.GetComponent<Timer>().timerIsRunning = false;
        }

        if (ingame && GetComponent<Timer>().perdeu == true)
        {
            perdeu();
        }

    }

    public void niveis()
    {


        if (dificuldade == 1)
        {
           this.GetComponent<Timer>().timeRemaining= tempo_facil;
            telaganhou.SetActive(false);
            telatimeup.SetActive(false);
            telaescolha.SetActive(false);
            Level.SetActive(true);
            this.GetComponent<Timer>().enabled = true;
            this.GetComponent<Timer>().timerIsRunning = true;
            jogandolevel = 1;
            ingame = true;
            Perdeu = false;
            Ganhou = false;
            controlador.Comecajogo();


        }

        if (dificuldade == 2)
        {
           this.GetComponent<Timer>().timeRemaining = tempo_medio;
            telaganhou.SetActive(false);
            telatimeup.SetActive(false);
            telaescolha.SetActive(false);
            Level.SetActive(true);
            this.GetComponent<Timer>().enabled = true;
            this.GetComponent<Timer>().timerIsRunning = true;
            jogandolevel = 2;
            ingame = true;
            Perdeu = false;
            Ganhou = false;
            controlador.Comecajogo();

        }

        if (dificuldade == 3)
        {
            this.GetComponent<Timer>().timeRemaining = tempo_dificil;
            telaganhou.SetActive(false);
            telatimeup.SetActive(false);
            telaescolha.SetActive(false);
            Level.SetActive(true);
            this.GetComponent<Timer>().enabled = true;
            this.GetComponent<Timer>().timerIsRunning = true;
            ingame = true;
            jogandolevel = 3;
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
        telatimeup.SetActive(false);
        telaescolha.SetActive(false);
        telaganhou.SetActive(true);
        Level.SetActive(false);
        this.GetComponent<Timer>().timerIsRunning = false;

        //  dificuldade = 0;

    }

    public void comeca1()
    {
        dificuldade = 1;
   
    }

    public void comeca2()
    {
        dificuldade = 2;

    }
    public void comeca3()
    {
        dificuldade = 3;

    }

    public void teladeescolha()
    {
        Ganhou = false;
        dificuldade = 0;
        ingame = false;
        Level.SetActive(false);
        telaescolha.SetActive(true);
        telaganhou.SetActive(false);
        controlador.Restart();


    }

}
