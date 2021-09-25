using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class ItemSelector : MonoBehaviour
{
    [SerializeField] public List<GameObject>Objetos = new List<GameObject>();

    private List<GameObject> recomeca= new List<GameObject>();
    private List<GameObject> Gestos = new List<GameObject>();
    private Vector3[] objetosInitialPosition { get; set; }
    protected int Totaldeobjetos;
    public int remove;
    private int pontos;
    [HideInInspector]    public bool victory;
    public bool teste;


    private GameObject _gesto;
    private string _nome;
   public void Comeca()
    {

        foreach (GameObject objetos in GameObject.FindGameObjectsWithTag("Objetos"))
        {
            Objetos.Add(objetos);

        }

        foreach (GameObject objetos in GameObject.FindGameObjectsWithTag("Gesto"))
        {
            Gestos.Add(objetos);
            objetos.SetActive(false);


        }

        recomeca = new List<GameObject> (Objetos);
        Objetos.Shuffle(Objetos.Count);
        // Debug.Log(Objetos.Count);

        _nome = Objetos[0].gameObject.name;
        _gesto = Gestos.Where(obj => obj.name == _nome).SingleOrDefault();
    
        Totaldeobjetos = Objetos.Count;
        _gesto.SetActive(true);

        
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
        _nome = Objetos[0].gameObject.name;
        _gesto = Gestos.Where(obj => obj.name == _nome).SingleOrDefault();
        for (int i = 0; i < Objetos.Count; i++)
        {

            Objetos[i].transform.position = objetosInitialPosition[i];
            Objetos[i].GetComponent<Collider2D>().enabled = true;
            recomeca[i].GetComponent<arrastavel>().acertou = false;
            recomeca[i].GetComponent<arrastavel>().check = false;


        }

        for (int i = 0; i < Gestos.Count; i++)
        {

            Gestos[i].GetComponent<MVerificaDificuldade>().Operator();


        }
        victory = false;
        teste = false;
        _gesto.SetActive(true);



    }

    // Update is called once per frame
    void Update()
    {

        if (pontos <Totaldeobjetos)
            if (remove == 1)
           StartCoroutine ("Remove");
        else
                remove = 0;

        if (Objetos.Count == 0)
        {
                       victory = true;
        }

        if (teste)
            Restart();

        //Debug.Log(i);
    }

    IEnumerator Remove()
    {
        remove = 0;
        if (pontos <Totaldeobjetos && Objetos.Count != 0)
            Objetos.RemoveAt(0);
        _gesto.SetActive(false);

        pontos += 1;
        // Debug.Log(i);
        yield return new WaitForSeconds(0.2f *Time.deltaTime);

        if (Objetos.Count != 0)
        {

            _nome = Objetos[0].gameObject.name;
            _gesto = Gestos.Where(obj => obj.name == _nome).SingleOrDefault();
            _gesto.SetActive(true);
            
            yield return new WaitForSeconds(0.1f * Time.deltaTime);
            Comecajogo();




        }


        

        
    }

    public void Comecajogo()
    {
        foreach (GameObject objetos in GameObject.FindGameObjectsWithTag("Gesto"))
        {
            Image image;
            image = objetos.GetComponent<Image>();
            var tempColor = image.color;
            tempColor.a = 1f;
            image.color = tempColor;

        }
    }
        }
