using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MochilaGameStarter : MonoBehaviour
{
    public GameObject Level;
    [Header("Níveis de Dificuldade")]
    public int dificuldade;
    public int tempo_facil;
    public int tempo_medio;
    public int tempo_dificil;

    [Header("Telas")]
    public GameObject telaescolha;
    public GameObject telatimeup;
    public GameObject telaganhou;
    [HideInInspector] public bool ingame;
    private bool Ganhou;
    private bool Perdeu;
    private int nivel = 0;
    private int niveiscompletos;
    public ItemSelector controlador;




    void Start()
    {
        niveiscompletos = PlayerPrefs.GetInt("nivelmochila");
        
    }

    void Update()
    {
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
            if (nivel < 1)
            {
                nivel = 1;
                PlayerPrefs.SetInt("nivelmochila", 1);
            }
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

    void niveis()
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
            ingame = true;

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
            ingame = true;

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

        }

    }
    void perdeu()
    {
        Perdeu = true;
        telatimeup.SetActive(true);
        telaescolha.SetActive(false);
        Level.SetActive(false);
        dificuldade = 0;



    }

    void ganhou()
    {

        Ganhou = true;
        telatimeup.SetActive(false);
        telaescolha.SetActive(false);
        telaganhou.SetActive(true);
        Level.SetActive(false);
        dificuldade = 0;

    }
}
