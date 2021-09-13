using UnityEngine;
using System.Collections.Generic;

public class Test : MonoBehaviour
{
    [SerializeField] public List<GameObject> objetos = new List<GameObject>();
    public Vector3[] objetosInitialPosition { get; set; }
    public bool teste;

    // Use this for initialization
    void Start()
    {
        objetosInitialPosition = new Vector3[objetos.Count];
        for (int i = 0; i < objetos.Count; i++)
        {
            objetosInitialPosition[i] = objetos[i].transform.position;
        }
    }

    private void Update()
    {
        if (teste)
            recomeca();
    }
    void recomeca()
    {
        objetos.Shuffle(objetos.Count);
        for (int i = 0; i < objetos.Count; i++)
        {
            
            objetos[i].transform.position = objetosInitialPosition[i];
            objetos[i].GetComponent<Collider2D>().enabled = true;
            teste = false;

        }


    }

}