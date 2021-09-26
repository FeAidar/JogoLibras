using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotaoLetra : MonoBehaviour
{
    [SerializeField]private int numero;
    public char letra;
    public void aciona(){
        GameObject.FindGameObjectWithTag("canvas").GetComponent<AlfabetoManejo>().BTM_add(numero);
    }

}
