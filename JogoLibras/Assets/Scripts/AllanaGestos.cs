using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllanaGestos : MonoBehaviour
{
    public bool Oi;
    public bool TudoBem;
    private Animator animator;

    
    // Start is called before the first frame update
    void Start()
    {
       animator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Oi)
        {
            TudoBem = false;
            oi();
        }

        if(TudoBem)
        {
            Oi = false;
            tudopom();
        }
    }


    public void oi()
    {
        Oi = false;
        animator.Play("Animacao tuto");

    }

    public void tudopom()
    {
        TudoBem = false;
        animator.Play("Tudo bem");

    }
}
