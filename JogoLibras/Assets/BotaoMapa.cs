using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotaoMapa : MonoBehaviour
{
    public int level;
    private Posicionaplayer Controlador;
    


    void Start()
    {
        Controlador = FindObjectOfType<Posicionaplayer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void apertou()
    {
        Controlador.fase = level;
        Controlador.apertou = true;
    }
}
