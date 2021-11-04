using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MateriasSystem : MonoBehaviour
{
    /*
        1. pega as variaveis do game definer
        2. escolhe quais materias
        3. coloca os objetos no lugar
        4. starta o timer
        5. verifica se o mouse esta precionado
        6. verifica se o objeto esta na materia certa
    */


    //game definer e variaveis
    private GameObject _Definer;
    private int _quantia,_difi;

    //timer
    private Timer tim;

    [Header("variaveis do jogo")]
    [SerializeField]private List<GameObject> Materias = new List<GameObject>();
    [SerializeField]private GameObject[] PosicoesMaterias;
    [SerializeField]private GameObject[] PosicoesItens;
    [SerializeField]private int[] Quantia;
    

    private List<GameObject> _MateriasEscolhidas = new List<GameObject>();
    private List<GameObject> _ItensRestantes = new List<GameObject>();
    private List<GameObject> _PosicoesMat = new List<GameObject>();
    private List<GameObject> _PosicoesIte = new List<GameObject>();
    public void Start(){
        GameDef();
        DefineMaterias();
        PegaPosicoes();
        DefinePosicoes();
    }

    void GameDef(){
        _Definer = GameObject.FindGameObjectWithTag("GameController");
        _quantia = _Definer.GetComponent<GameDefiner>().Quantia;
        _difi = _Definer.GetComponent<GameDefiner>().Dificuldade;
    }
    void DefineMaterias(){
        int a = Quantia[_quantia];
        for (int i = 0; i < a; i++)
        {
            int b = Random.Range(0, Materias.Count);
            _MateriasEscolhidas.Add(Materias[b]);
            Materias.Remove(Materias[b]);
        }
        foreach (GameObject b in _MateriasEscolhidas)
        {
            int c = b.transform.GetChild(0).transform.childCount;
            for (int i = 0; i < c; i++)
            {
                _ItensRestantes.Add(b.transform.GetChild(0).transform.GetChild(i).gameObject);
            }
        }
        foreach(GameObject r in Materias){
            r.SetActive(false);
        }
    }
    void PegaPosicoes(){
        int a = PosicoesMaterias[_quantia].transform.childCount;
        for (int i = 0; i < a; i++)
        {
            _PosicoesMat.Add(PosicoesMaterias[_quantia].transform.GetChild(i).gameObject);
        }
        int b = PosicoesItens[_quantia].transform.childCount;
        for (int i = 0; i < b; i++)
        {
            _PosicoesIte.Add(PosicoesItens[_quantia].transform.GetChild(i).gameObject);
        }
    }

    void DefinePosicoes(){
        foreach (GameObject a in _MateriasEscolhidas)
        {
            int c = Random.Range(0,_PosicoesMat.Count);
            a.transform.position = _PosicoesMat[c].transform.position;
            _PosicoesMat.Remove(_PosicoesMat[c]);
        }
        foreach (GameObject e in _ItensRestantes)
        {
            int f = Random.Range(0,_PosicoesIte.Count);
            e.GetComponent<ObjetoMaterial>().posicao = _PosicoesIte[f];
            _PosicoesIte.Remove(_PosicoesIte[f]);
        }
    }
}