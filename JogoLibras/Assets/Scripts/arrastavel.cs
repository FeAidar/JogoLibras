using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrastavel : MonoBehaviour
{

    public bool IsDragging;
    public Vector3 LastPosition;
    

    private Collider2D _collider;

    private DragController _dragController;

    private float _movementTime = 15f;
    private System.Nullable<Vector3> _movementDestination;
    private ItemSelector _Objetos;
    public bool acertou;
    private string firstobject;
    public bool check;
    private AudioSource SomLugarErrado;
    private bool _som;





    private void Start()
    {
              _collider = GetComponent<Collider2D>();
       _dragController = FindObjectOfType<DragController>();
        _Objetos = FindObjectOfType<ItemSelector>();
        SomLugarErrado = GetComponent<AudioSource>();
       
        


    }

    private void Update()
    {
        //Debug.Log(_collider);
    }
    private void FixedUpdate()
    {
        if(!acertou)
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
                    if(check)
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

        if (_Objetos.GetComponent<ItemSelector>().Objetos.Count != 0)
            firstobject = _Objetos.GetComponent<ItemSelector>().Objetos[0].gameObject.name;


        else
            firstobject = "Parabéns";
       // Debug.Log(firstobject);

    }

    void Som()
    {
        if (!_som)
            if (SomLugarErrado != null)
            {
                SomLugarErrado.Play();
                _som = true;
            }
    }

    void Acertou()
    {
        if(!acertou)
        {
            acertou = true;
            _Objetos.GetComponent<ItemSelector>().remove += 1;
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
                    Debug.Log("ERRADO");
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
