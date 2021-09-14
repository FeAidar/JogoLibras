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
    private int nivel;
    private ItemSelector controlador;
    [HideInInspector] public int jogandolevel;





    void Start()
    {
        nivel = PlayerPrefs.GetInt("nivelmochila1");
        controlador = FindObjectOfType<ItemSelector>();
        jogandolevel = 0;


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
            if (jogandolevel == 1)
            {
                PlayerPrefs.SetInt("nivelmochila1", 1);
                
            }


            if (jogandolevel == 2)
            {
                
                PlayerPrefs.SetInt("nivelmochila1", 2);
                Ganhou = true;
            }


            if (jogandolevel == 3)
            {
                
                PlayerPrefs.SetInt("nivelmochila1", 3);
                Ganhou = true;
            }
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
