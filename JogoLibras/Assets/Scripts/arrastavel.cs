using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrastavel : MonoBehaviour
{

    public bool IsDragging;
    public Vector3 LastPosition;
    

    private Collider2D _collider;

    private DragController _dragController;
    private MochilaGameStarter _Objetos;
    private float _movementTime = 15f;
    private System.Nullable<Vector3> _movementDestination;
    public bool acertou;
    private string firstobject;
    public bool check;
    private AudioSource SomLugarErrado;
    private bool _som;
    private GameObject acerto, erro;
    private bool umaVez = true;

    private void Start()
    {
        _collider = GetComponent<Collider2D>();
        _dragController = FindObjectOfType<DragController>();
        _Objetos = FindObjectOfType<MochilaGameStarter>();
        SomLugarErrado = GetComponent<AudioSource>();
        acerto = GameObject.FindGameObjectWithTag("acerto");
        /*
            acerto.GetComponent<Animator>().SetTrigger("desativo");
            if(umaVez== true){
                acerto.GetComponent<Animator>().SetTrigger("ativo");
                acerto.transform.position = this.transform.position;
                umaVez = false;
            }
        */
        erro = GameObject.FindGameObjectWithTag("erro");
        /*
            erro.GetComponent<Animator>().SetTrigger("desativo");
            erro.GetComponent<Animator>().SetTrigger("ativo");
        */
    }

    private void Update()
    {
        //Debug.Log(_collider);
    }
    private void FixedUpdate()
    {
        if (Time.timeScale == 1)
        {
            if (!acertou)
            {

                if (_movementDestination.HasValue)
                {
                    if (IsDragging)
                    {
                        _movementDestination = null;
                        return;
                    }
                    if (transform.position == _movementDestination)
                    {
                        gameObject.layer = Layer.Default;
                        _movementDestination = null;
                        _som = false;
                        if (check)
                        {
                            if (!IsDragging)
                                if (name == firstobject)
                                {
                                    // Debug.Log("testando");
                                    Acertou();
                                }
                        }

                    }
                    else
                    {
                        transform.position = Vector3.Lerp(transform.position, _movementDestination.Value, _movementTime * Time.fixedDeltaTime);


                    }

                }
            }

            if (_Objetos.Objetos.Count != 0)
            {
                firstobject = _Objetos.Objetos[0].gameObject.name;
            }
            else
            {
                firstobject = "Parab�ns";
                // Debug.Log(firstobject);
            }
        }

    }

    void Som()
    {
        if (!_som){
            if (SomLugarErrado != null)
            {
                SomLugarErrado.Play();
                _som = true;
            }
        }
    }

    void Acertou()
    {
        if(!acertou)
        {
            acertou = true;
            _Objetos.remove += 1;
           this.GetComponent<Collider2D>().enabled=false;
        }
        
    }
    void OnTriggerStay2D(Collider2D other)

    {
        arrastavel collidedarrastavel = other.GetComponent<arrastavel>();

        if (collidedarrastavel != null && _dragController.LastDragged.gameObject == gameObject)
        {
            ColliderDistance2D colliderDistance2D = other.Distance(_collider);
            Vector3 diff = new Vector3(colliderDistance2D.normal.x, colliderDistance2D.normal.y) * colliderDistance2D.distance;
            transform.position -= diff;
        }
            if (name == firstobject)
            {
            if (other.CompareTag("Area Valida"))
            {
                if (!IsDragging)
                {
                    check = true;
                    _movementDestination = other.transform.position;
                   // Debug.Log(check);
                }
            }
            else if (other.CompareTag("AreaInvalida"))
                if (!IsDragging && !check)
                {
                   // check = false;
                    _movementDestination = LastPosition;
                    
                }
            }
            else
            {
            if (other.CompareTag("Area Valida"))
            {
                if (!IsDragging && !check)
                {
                   // check = false;
                    _movementDestination = LastPosition;
                }

            }
            else if (other.CompareTag("AreaInvalida"))
            {
                if (!IsDragging && !check)
                {
                  //  check = false;
                    _movementDestination = LastPosition;
                    //Debug.Log("ERRADO");
                    Som();
                }
            }
        }
    }

    void movendo()
    {
        check = false;
    }

}
