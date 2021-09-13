using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSelector : MonoBehaviour
{
    [SerializeField] public List<GameObject>Objetos = new List<GameObject>();
    private List<GameObject> recomeca= new List<GameObject>();
    private Vector3[] objetosInitialPosition { get; set; }
    protected int Totaldeobjetos;
    public int remove;
    private int pontos;
    public Text Objeto;
    [HideInInspector]    public bool victory;
    public bool teste;
    void Start()
    {

        recomeca = new List<GameObject> (Objetos);
        Objetos.Shuffle(Objetos.Count);
       // Debug.Log(Objetos.Count);
        Totaldeobjetos = Objetos.Count;
        Objeto.text = Objetos[0].gameObject.name;
        objetosInitialPosition = new Vector3[Objetos.Count];
        for (int i = 0; i < Objetos.Count; i++)
        {
            objetosInitialPosition[i] = Objetos[i].transform.position;
        }



    }
    public void Restart()
    {
        Objetos = new List<GameObject> (recomeca);
        pontos = 0;
        Objetos.Shuffle(Objetos.Count);
        // Debug.Log(Objetos.Count);
        Totaldeobjetos = Objetos.Count;
        Objeto.text = Objetos[0].gameObject.name;
        for (int i = 0; i < Objetos.Count; i++)
        {

            Objetos[i].transform.position = objetosInitialPosition[i];
            Objetos[i].GetComponent<Collider2D>().enabled = true;
            recomeca[i].GetComponent<arrastavel>().acertou = false;
            recomeca[i].GetComponent<arrastavel>().check = false;


        }
        victory = false;
        teste = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (pontos <Totaldeobjetos)
            if (remove == 1)
            Remove();
        else
                remove = 0;

        if (Objetos.Count == 0)
        {
            Objeto.text = " ";
            victory = true;
        }

        if (teste)
            Restart();

        //Debug.Log(i);
    }

    void Remove()
    {
        if(pontos <Totaldeobjetos && Objetos.Count != 0)
            Objetos.RemoveAt(0);
        pontos += 1;
       // Debug.Log(i);

        if (Objetos.Count != 0)
        {
            
            Objeto.text = Objetos[0].gameObject.name;
            
          
        }


        remove = 0;

        
    }
}
