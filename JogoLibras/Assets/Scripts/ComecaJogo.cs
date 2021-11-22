using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComecaJogo : teleport
{
    [Header("Level para carregar")]
    [SerializeField] public string LevelCustomizacao;
    void Start()
    {
        Som = GetComponent<AudioSource>();
        _transicao = GameObject.FindWithTag("Transicao").GetComponent<transicao>();
        PlayerPrefs.SetInt("fasenomapa", 0);

    }

    public void CarregaCustomizacao()
    {
         if (PlayerPrefs.HasKey("Introducao"))
        {
            if (PlayerPrefs.GetInt("Introducao") == 1)
            {
                StartCoroutine ("Carrega", level);

            }
            if (PlayerPrefs.GetInt("Introducao") == 0)
            {
                _transicao.inicia();
                StartCoroutine("Carrega", LevelCustomizacao);

            }
        }
        else
            StartCoroutine("Carrega", LevelCustomizacao);


    }
}
