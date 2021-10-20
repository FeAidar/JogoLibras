using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FezCustomizacao : teleport
{
    // Start is called before the first frame update
    void Start()
    {
        Som = GetComponent<AudioSource>();
        _transicao = GameObject.FindWithTag("Transicao").GetComponent<transicao>();
    }

public void teleport()
    {
        PlayerPrefs.SetInt("Customizou", 1);
        Carregalevel();

    }
}
