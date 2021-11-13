using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Posicionaplayer : MonoBehaviour
{
    [SerializeField] public List<GameObject> pontos = new List<GameObject>();
    [SerializeField] private float velocidade;
    private int FaseAtual;
    public int fase;
    void Start()
    {
        FaseAtual = PlayerPrefs.GetInt("fasenomapa");
        fase = PlayerPrefs.GetInt("fasenomapa");

        transform.position = pontos[FaseAtual].transform.position;


    }

    // Update is called once per frame
    void Update()
    {
        Anda();



    }
    void garantia()
    { GetComponentInParent<ScrollRect>().enabled = true;

    }

    private void GetCaminho()
    {
        GameObject pack = GameObject.FindGameObjectWithTag("Fase");
        int a = pack.transform.childCount;
        for (int i = 0; i < a; i++)
        {
            pontos.Add(pack.transform.GetChild(i).gameObject);
        }
    }
    private void Anda()
    {
        if (FaseAtual <= pontos.Count - 1)
        {

            transform.position = Vector3.MoveTowards(transform.position, pontos[FaseAtual].transform.position, velocidade * Time.deltaTime);
           // Debug.Log(transform.position + "posição do player");
           // Debug.Log(pontos[FaseAtual].transform.position + "fase atual");
           // Debug.Log(pontos.Count + "quantas fases");
            
            if (transform.position == pontos[FaseAtual].transform.position)
            {
                if (FaseAtual < fase)
                    FaseAtual += 1;
                

                if (FaseAtual > fase)
                    FaseAtual -= 1;

                if (FaseAtual == fase)
                    garantia();

            }
            else GetComponentInParent<ScrollRect>().enabled = false;
        }

    }
}
