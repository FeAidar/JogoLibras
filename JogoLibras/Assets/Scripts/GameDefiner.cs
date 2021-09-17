using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDefiner : MonoBehaviour
{
    public int Dificuldade;
    public int pack;
    public int Quantia;
    public int QuantiaEstrela;
    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }
    
}
