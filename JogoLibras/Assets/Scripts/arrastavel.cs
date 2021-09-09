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

    private void Start()
    {
        _collider = GetComponent<Collider2D>();
        _dragController = FindObjectOfType<DragController>();
    }

    private void FixedUpdate()
    {
        if (_movementDestination.HasValue)
        {
            if (IsDragging)
            {
                _movementDestination = null;
                return;
            }
        if (transform.position==_movementDestination)
            {
                gameObject.layer = Layer.Default;
                _movementDestination = null;
                

            }
            else
            {
                transform.position = Vector3.Lerp(transform.position, _movementDestination.Value, _movementTime * Time.fixedDeltaTime);
            }
        
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
            Debug.Log("teste");
        }

        if(other.CompareTag("Area Valida"))
        {
            _movementDestination = other.transform.position;

        }
        else if (other.CompareTag("AreaInvalida"))
        {
            _movementDestination = LastPosition;
        }
    }

}
