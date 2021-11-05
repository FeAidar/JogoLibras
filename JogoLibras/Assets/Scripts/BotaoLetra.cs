using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BotaoLetra : MonoBehaviour
{
    [SerializeField]public int numero;
    public GameObject Mao;
    public GameObject Letra;
    public GameObject Legenda;
    public char letra;
    public void aciona(){
        GameObject.FindGameObjectWithTag("canvas").GetComponent<AlfabetoManejo>().BTM_add(numero);
    }
    private void Start(){
        EntraLetra();


    }

    public void EntraLetra()
    {
        if (GetComponentInParent<Alfabeto>().Etapa == 0)
        {
            Mao.SetActive(false);
            Legenda.SetActive(false);
            Letra.SetActive(true);
        }
        if (GetComponentInParent<Alfabeto>().Etapa == 1)
        {
            Mao.SetActive(true);
            Legenda.SetActive(true);
            Letra.SetActive(false);
        }
        if (GetComponentInParent<Alfabeto>().Etapa == 2)
        {
            Mao.SetActive(true);
            Legenda.SetActive(false);
            Letra.SetActive(false);
        }
    }
}
