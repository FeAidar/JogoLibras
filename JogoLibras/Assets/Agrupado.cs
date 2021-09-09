using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agrupado : MonoBehaviour
{
    public List<GameObject> Filhos = new List<GameObject>(); 
    public List<bool> posi = new List<bool>();
    [SerializeField]private Vector2[] posicao;

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
}
