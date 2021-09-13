using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agrupado : MonoBehaviour
{
    public List<GameObject> Filhos = new List<GameObject>(); 
    public List<bool> posi = new List<bool>();
    [SerializeField]private Vector2[] posicao;
    [SerializeField]private float velocidade;
    public bool IndoE, IndoD;
    private bool lado;

    private void FixedUpdate(){
        if(IndoD== true){
            transform.Translate(Vector3.right *velocidade* Time.deltaTime);
        }
        if(IndoE==true){
            transform.Translate(Vector3.left *velocidade* Time.deltaTime);
        }
    }

    public void organiza(){
        int a;
        a = Filhos.Count;
        for (int i = 0; i < a; i++)
        {
            verifica(i);
        }
    }
    private void verifica(int i){
        int esse = Random.Range(0, Filhos.Count);
        if(posi[esse] == true){
            Filhos[i].transform.Translate(posicao[esse], Space.World);
            posi[esse] = false;
        }else{
            verifica(i);
        }
    }
    public void ladoE(bool ladu){
        IndoE = true;
        lado= true;
    }
    public void ladoD(bool ladu){
        IndoD= true;
        lado = false;
    }
    private void OnTriggerEnter2D(Collider2D other){
        if(other.tag.Equals("CenterD") && lado == false){
           // GameObject.FindGameObjectWithTag("canvas").GetComponent<PassaGrupos>().trocando = false;
            IndoD= false;
        }
        if(other.tag.Equals("CenterE") && lado ==true){
           // GameObject.FindGameObjectWithTag("canvas").GetComponent<PassaGrupos>().trocando = false;
            IndoE= false;
        }
    }
}
