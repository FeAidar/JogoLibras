using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Musica : MonoBehaviour
{
    private GameObject Trilha;
    
    // Start is called before the first frame update
    void Start()
    {
        Trilha = GameObject.FindWithTag("Musica");
        if (Trilha.GetComponent<AudioSource>().isPlaying == false)
            Trilha.GetComponent<AudioSource>().Play();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
