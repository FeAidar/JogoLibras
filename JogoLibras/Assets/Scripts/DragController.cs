using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragController : MonoBehaviour
{
    public arrastavel LastDragged => _lastDragged;
    private bool _isDragActive = false;
    private Vector2 _screenPosition;
    private Vector3 _worldPosition;
    private arrastavel _lastDragged;
    protected int pontos;
    

    private void Start()
    {

    }

    void Update()
    {
        if (_isDragActive && (Input.GetMouseButtonUp(0) || (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Ended)))
        {
            Drop();
            return;
        }

     if(Input.GetMouseButton(0))
    {
      Vector3 mousePos = Input.mousePosition;
          _screenPosition = new Vector2(mousePos.x, mousePos.y);
     }

     else if (Input.touchCount > 0 )
        {
            _screenPosition = Input.GetTouch(0).position;
        }
        else
        {
            return;
        }

        _worldPosition = Camera.main.ScreenToWorldPoint(_screenPosition);

        if(_isDragActive)
        { Drag(); }
        else
        {
            RaycastHit2D hit = Physics2D.Raycast(_worldPosition, Vector2.zero);
            if(hit.collider !=null)
            {
                arrastavel draggable = hit.transform.gameObject.GetComponent<arrastavel>();
                if (draggable != null)
                {
                    _lastDragged = draggable;
                    InitDrag();
                }
            }

        }
    }
    void InitDrag()
    {
        _lastDragged.LastPosition = _lastDragged.transform.position;
        UpdateDragStatus(true);
        //Debug.Log(_lastDragged.LastPosition);
    
    }

    void Drag()
    {
        _lastDragged.transform.position = new Vector2(_worldPosition.x, _worldPosition.y);

           

    }

    void Drop()
    {
        UpdateDragStatus(false);
        
    }

    void UpdateDragStatus(bool isDragging)
    {
        _isDragActive = _lastDragged.IsDragging = isDragging;
        gameObject.layer = isDragging ? Layer.Dragging : Layer.Default;
    }
}
