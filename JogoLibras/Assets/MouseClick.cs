using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseClick : MonoBehaviour
{
    private GameObject objeto;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0)){
            Debug.Log("click");
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if(hit.collider != null)
            {
                if(hit.transform.tag.Equals("objeto")){
                    objeto = hit.transform.gameObject;
                    objeto.GetComponent<ObjetoMaterial>().clicado = true;
                }
            }
        }
        if(Input.GetKeyUp(KeyCode.Mouse0)){
            if(objeto != null){
                objeto.GetComponent<ObjetoMaterial>().clicado = false;
                objeto = null;
            }
        }
    }
}
