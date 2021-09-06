using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDefiner : MonoBehaviour
{
    public int Dificuldade;
    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }
}
