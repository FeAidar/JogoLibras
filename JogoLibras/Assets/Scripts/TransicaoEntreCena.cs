using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransicaoEntreCena : MonoBehaviour
{
    private transicao Transicao;
    private GameObject t;
    void Start()
    {

    }

    private void OnEnable()

    {
        t = GameObject.FindGameObjectWithTag("Transicao");
        Transicao = t.GetComponent<transicao>();
        //Debug.Log(t);

        if (t.GetComponent<CanvasGroup>().alpha == (0))
            Transicao.inicia();
        else
                Transicao.finaliza();
            
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
