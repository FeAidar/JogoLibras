using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoDeCamera : MonoBehaviour
{
    private Vector3 StartingPos;
    private bool zoom;
    private float Settimer =0.5f;
    private float timer;
    Vector3 d = new Vector3 ();
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0)){
            StartingPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if(timer >= Time.time){
                Debug.Log("b");
                if(zoom){
                    Camera.main.orthographicSize = 5f;
                    zoom = false;
                    if(Camera.main.transform.position.x < 5 && Camera.main.transform.position.x > -5){
                        d.x = Camera.main.transform.position.x;
                    }else{
                        if(Camera.main.transform.position.x >= 5){
                            d.x= 4.9f;
                        }
                        if(Camera.main.transform.position.x <= -5){
                            d.x= -4.9f;
                        }
                    }
                }else{
                    Camera.main.orthographicSize = 2.5f;
                    zoom = true;
                }
            }else{
                Debug.Log("a");
                timer = Settimer + Time.time;
            }
        }
        if(Input.GetKey(KeyCode.Mouse0)){
            Vector3 Direction = StartingPos - Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if(zoom == false){
                Direction.y = 0;
                if(d.x < 5 && d.x > -5){
                    d += Direction;
                }else{
                    if(d.x > 5 && Direction.x < 0){
                        d += Direction;
                    }
                    if(d.x < -5 && Direction.x > 0){
                        d += Direction;
                    }
                }
                d.y = 0;
                Camera.main.transform.position = d;
            }else{
                if(d.x < 6.25f && d.x > -6.25f){
                    d.x += Direction.x;
                }else{
                    if(d.x > 6.25f && Direction.x < 0){
                        d.x += Direction.x;
                    }
                    if(d.x < -6.25f && Direction.x > 0){
                        d.x += Direction.x;
                    }
                }
                if(d.y < 2.5f && d.y > -2.5f){
                    d.y += Direction.y;
                }else{
                    if(d.y > 2.5f && Direction.y < 0){
                        d.y += Direction.y;
                    }
                    if(d.y < -2.5f && Direction.y > 0){
                        d.y += Direction.y;
                    }
                }
                Camera.main.transform.position = d;
            }
        }
    }
}
