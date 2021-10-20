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

    }

    public void CarregaCustomizacao()
    {
        if (PlayerPrefs.HasKey("Customizou"))
        {
            if (PlayerPrefs.GetInt("Customizou") == 1)
            {
                StartCoroutine ("Carrega", level);

            }
            if (PlayerPrefs.GetInt("Customizou") == 0)
            {
                StartCoroutine("Carrega", LevelCustomizacao);

            }
        }
        else
            StartCoroutine("Carrega", LevelCustomizacao);


    }
}
