using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Descricao : MonoBehaviour
{
    [SerializeField] public List<string> Descricoes = new List<string>();
    [SerializeField] public List<string> Mapas = new List<string>();
    public GameObject Botao;
    private GameObject descricao;
    private Posicionaplayer controller;
    private Text textodescricao;
    

    void Start()
    {
        controller = FindObjectOfType<Posicionaplayer>();
        descricao =GameObject.Find("Descrição");
        textodescricao = descricao.GetComponent<Text>();
       
    }

    // Update is called once per frame
    void Update()
    {
        
        if(controller.fase==0)
        {
            textodescricao.text = "";
            Botao.SetActive(false);
        }
        else
        {
            Botao.SetActive(true);
            textodescricao.text = Descricoes[controller.fase];
            Botao.GetComponent<teleport>().level = Mapas[controller.fase];
        }


    }
}
