using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDefiner : MonoBehaviour
{
    public int Dificuldade;
    public int pack;
    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }
}
