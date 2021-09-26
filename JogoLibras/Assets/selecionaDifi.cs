using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selecionaDifi : MonoBehaviour
{
    [SerializeField]private int Minigame;
    [SerializeField]private int[] dificuldade;
    [SerializeField]private int[] pack;
    [SerializeField]private int[] Quantia;
    private GameObject definer;
    private CartaManege memoria;
    private WordManege palavras;
    private AlfabetoManejo alfabeto;

    void Start()
    {
        definer = GameObject.FindGameObjectWithTag("GameController");
        switch(Minigame)
        {
            case 0:
                memoria = GameObject.FindGameObjectWithTag("canvas").GetComponent<CartaManege>();
            break;
            case 1:
                palavras = GameObject.FindGameObjectWithTag("canvas").GetComponent<WordManege>();
            break;
            case 2:
                alfabeto = GameObject.FindGameObjectWithTag("canvas").GetComponent<AlfabetoManejo>();
            break;
        }
    }

    public void facil(){
        definer.GetComponent<GameDefiner>().Dificuldade = dificuldade[0];
        definer.GetComponent<GameDefiner>().Quantia = Quantia[0];
        definer.GetComponent<GameDefiner>().pack = pack[0];
        switch(Minigame)
        {
            case 0:
                memoria.comeca();
            break;
            case 1:
                palavras.comeca();
            break;
            case 2:
                alfabeto.comeca();
            break;
        }
        this.gameObject.SetActive(false);
    }
    public void Medio(){
        definer.GetComponent<GameDefiner>().Dificuldade = dificuldade[1];
        definer.GetComponent<GameDefiner>().Quantia = Quantia[1];
        definer.GetComponent<GameDefiner>().pack = pack[1];
        switch(Minigame)
        {
            case 0:
                memoria.comeca();
            break;
            case 1:
                palavras.comeca();
            break;
            case 2:
                alfabeto.comeca();
            break;
        }
        this.gameObject.SetActive(false);
    }
    public void Dificil(){
        definer.GetComponent<GameDefiner>().Dificuldade = dificuldade[2];
        definer.GetComponent<GameDefiner>().Quantia = Quantia[2];
        definer.GetComponent<GameDefiner>().pack = pack[2];
        switch(Minigame)
        {
            case 0:
                memoria.comeca();
            break;
            case 1:
                palavras.comeca();
            break;
            case 2:
                alfabeto.comeca();
            break;
        }
        this.gameObject.SetActive(false);
    }
}

