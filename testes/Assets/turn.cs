using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turn : MonoBehaviour
{
    private bool lado= true, virando;
    [SerializeField] private float VeloTurn;
    
    void FixedUpdate()
    {
        if(virando){
            if(lado){
                Quaternion target = Quaternion.Euler(transform.rotation.x , -180f, transform.rotation.z);
                if(transform.rotation.eulerAngles.y == 180f ){
                    Debug.Log("parou");
                    lado = false;
                    virando = false;
                }else{
                    Debug.Log("virando ");
                    transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * VeloTurn);
                }
            }else{
                Quaternion target = Quaternion.Euler(transform.rotation.x , 180f, transform.rotation.z);
                if(transform.rotation.eulerAngles.y == -180f){
                    Debug.Log("parou");
                    lado = true;
                    virando = false;
                }else{
                    Debug.Log("virando " + transform.rotation.eulerAngles.y);
                    transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * VeloTurn);
                }
            }
            
        }
    }
    public void clicou(){
        virando = true;
    }
}
