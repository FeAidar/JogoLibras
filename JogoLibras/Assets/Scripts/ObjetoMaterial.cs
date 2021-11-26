using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetoMaterial : MonoBehaviour
{
    [SerializeField]private GameObject materia;
    public MateriasSystem sistema;
    public GameObject posicao;
    public bool clicado;
    private bool posicionado, posivel= true;
    public AudioSource Acertou;
    public AudioSource Errou;
    void Start(){
        sistema = GameObject.FindGameObjectWithTag("Sistema").GetComponent<MateriasSystem>();
    }

    void Update(){
        if(sistema.startado == true && sistema.podemexer==true){
            Debug.Log("porra");
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
                        sistema.itensRestantes.Remove(this.gameObject);
                        posivel = false;
                        sistema.verificaGanhou();
                    }
                }
        }
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject == materia){
            posicionado = true;
            Acertou.Play();
        }
    }
    void OnTriggerExit2D(Collider2D other){
        if(other.gameObject == materia){
            posicionado = false;
            Errou.Play();
        }
    }
}
