using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MochilaGameStarter : MonoBehaviour
{
    private GameDefiner _definer;
    [Header("Packs")]
    [SerializeField] public List<GameObject> packs;
    public int TempoPerdeuDuasEstrelas;



    [Header("Telas")]
    public GameObject telatimeup;
    public GameObject telaganhou;
    public Text Estrelas;

    [HideInInspector] public bool ingame;
    private bool Ganhou;
    private bool Perdeu;
    private ItemSelector controlador;


  private bool _start;
    

    [Header("Itens")]
    private List<GameObject> Gestos = new List<GameObject>();
    private Vector3[] objetosInitialPosition { get; set; }
    protected int Totaldeobjetos;
    private GameObject _gesto;
    private string _nome;


    [HideInInspector] public int remove;

    void Start()
    {
        Estrelas.text = string.Format ("3 Estrelas");
        controlador = FindObjectOfType<ItemSelector>();
        _definer = FindObjectOfType<GameDefiner>();
        TempoPerdeuDuasEstrelas = _definer.TempoDuasEstrelas;

        if (_definer.pack == 0)
            return;
        else
           Level = Instantiate(packs[_definer.pack - 1]);

        nivel = PlayerPrefs.GetInt(SceneManager.GetActiveScene().name + _definer.Dificuldade_do_Minigame + _definer.pack);
        Debug.Log(nivel);

        controlador.Comeca();
      

            JogoComecou = true;
    }

    void Update()
    {
        if (!ingame)
        {
            this.GetComponent<Timer>().timerIsRunning = false;
            if (!Perdeu)
            if (ItensConseguidos < Totaldeobjetos)

            {
                telaescolha.SetActive(true);
                ComecaJogo();
            }

            if (Ganhou)
            // Sobre o resto
            {
                telaescolha.SetActive(false);
                    _timer.timeRemaining = _definer.Tempo;
                    _timer.timerIsRunning = true;
            }
                if(!Perdeu && !Ganhou)
            {
                telaescolha.SetActive(true);
                ComecaJogo();
                _timer.timerIsRunning = true;
                StarCounter();
            }

            
        



            {
        }
    }

        else
        {
            {

                if (GetComponent<Timer>().timeRemaining > TempoPerdeuUmaEstrela)
                {
                }

                if (GetComponent<Timer>().timeRemaining > TempoPerdeuDuasEstrelas && GetComponent<Timer>().timeRemaining < TempoPerdeuUmaEstrela)
            if (GetComponent<Timer>().timeRemaining > TempoPerdeuDuasEstrelas && GetComponent<Timer>().timeRemaining < TempoPerdeuUmaEstrela)
            {
                Estrelas.text = string.Format("2 Estrelas");
                _definer.QuantiaEstrela = 2;
            }

            if (GetComponent<Timer>().timeRemaining < TempoPerdeuDuasEstrelas && GetComponent<Timer>().timeRemaining != 0)
            {
                Estrelas.text = string.Format("1 Estrela");
                _definer.QuantiaEstrela = 1;
            }
            if (GetComponent<Timer>().timeRemaining < 0.05f)
            {
                Estrelas.text = string.Format("0 Estrelas");
                _definer.QuantiaEstrela = 0;
            }
        }
    }

    public void ListaDeItens()
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

        recomeca = new List<GameObject>(Objetos);
        Objetos.Shuffle(Objetos.Count);
        
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


    public void RestartListadeItens()
    {
        Objetos = new List<GameObject>(recomeca);
        ItensConseguidos = 0;
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
        Ganhou = false;
        _gesto.SetActive(true);



    }

    IEnumerator RemoveItens()
    {
        remove = 0;
        if (ItensConseguidos < Totaldeobjetos && Objetos.Count != 0)
            Objetos.RemoveAt(0);
        if (AcertouItem != null)
            AcertouItem.Play();
        _gesto.SetActive(false);


        ItensConseguidos += 1;
           yield return new WaitForSeconds(0.2f * Time.deltaTime);

        if (Objetos.Count != 0)
        {

            _nome = Objetos[0].gameObject.name;
            _gesto = Gestos.Where(obj => obj.name == _nome).SingleOrDefault();
            _gesto.SetActive(true);

            yield return new WaitForSeconds(0.1f * Time.deltaTime);
            ProximoItem();


        }





    }

    public void ProximoItem()
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

    public void RecomecaJogo()
    {
        _timer.StartCoroutine("GetStarsPositions");
        RestartListadeItens();
            _timer.tempo = _definer.Tempo;
            _timer.timeRemaining = _definer.Tempo;
            telaganhou.SetActive(false);
            telatimeup.SetActive(false);
            Perdeu = false;
            Ganhou = false;
            _timer.enabled = true;
            _timer.timerIsRunning = true;
            ingame = true;
            Perdeu = false;
            Ganhou = false;
           
        



    }
    void perdeu()
    {
        Perdeu = true;
        telatimeup.SetActive(true);
        
    }

    void ganhou()
    {
        if (!Ganhou)
        {
            _definer.ganhou();
        }
        Ganhou = true;

        // --- SOM VITORIA
        telatimeup.SetActive(false);
        
        telaganhou.SetActive(true);
 
        _timer.timerIsRunning = false;

    }


}
