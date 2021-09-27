using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Posicionaplayer : MonoBehaviour
{
    
    public bool apertou;
    public Vector3 Fase;
    [HideInInspector] public int fase;
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {


        if(apertou)
            {
            if (transform.position == Fase + (Vector3.down))
            {
                GetComponentInParent<ScrollRect>().enabled = true;
                apertou = false;
             
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, Fase + (Vector3.down), 500f * Time.deltaTime);
                GetComponentInParent<ScrollRect>().enabled = false;
                Invoke("garantia", 1f * Time.deltaTime);
           
            }
            }
        else
            GetComponentInParent<ScrollRect>().enabled = true;


    }
    void garantia()
    { GetComponentInParent<ScrollRect>().enabled = true;
        Debug.Log("invocoume");
    }
}
