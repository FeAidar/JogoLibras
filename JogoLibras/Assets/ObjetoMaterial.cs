using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetoMaterial : MonoBehaviour
{
    [SerializeField]private GameObject materia;
    public GameObject posicao;
    public bool clicado;
    private bool posicionado, posivel= true;

    void Update(){
        if(posivel == true){
            if(clicado == true ){
                Vector3 a = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                a.z = 0;
                this.transform.position = a;
            }else if(clicado == false && posicionado == false){
                this.transform.position = posicao.transform.position;
            }else if(clicado == false && posicionado == true){
                this.transform.position = materia.transform.GetChild(1).transform.GetChild(0).transform.position;
                Destroy(materia.transform.GetChild(1).transform.GetChild(0).transform.gameObject);
                posivel = false;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject == materia){
            posicionado = true;
        }
    }
    void OnTriggerExit2D(Collider2D other){
        if(other.gameObject == materia){
            posicionado = false;
        }
    }
}
