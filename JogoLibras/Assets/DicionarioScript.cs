using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DicionarioScript : MonoBehaviour
{
    [SerializeField]private GameObject[] paginas;
    private int paginaAtual;

    private void Start(){
        foreach (GameObject b in paginas)
        {
            b.SetActive(false);
        }
        paginas[paginaAtual].SetActive(true);
    }

    public void Proximo(){
        if(paginaAtual < paginas.Length-1){
            paginas[paginaAtual].SetActive(false);
            paginaAtual++;
            paginas[paginaAtual].SetActive(true);
        }
    }
    public void Anterior(){
        if(paginaAtual > 0){
            paginas[paginaAtual].SetActive(false);
            paginaAtual--;
            paginas[paginaAtual].SetActive(true);
        }
    }
    public void Ultimo(){
        paginas[paginaAtual].SetActive(false);
        paginaAtual = paginas.Length-1;
        paginas[paginaAtual].SetActive(true);
    }
    public void Primeiro(){
        paginas[paginaAtual].SetActive(false);
        paginaAtual = 0;
        paginas[paginaAtual].SetActive(true);
    }
    public void ParaAPagina(int a){
        paginas[paginaAtual].SetActive(false);
        paginaAtual = a;
        paginas[paginaAtual].SetActive(true);
    }
    public void CarregaCena(string name){

    }
}
