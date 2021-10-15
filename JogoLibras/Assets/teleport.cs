using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class teleport : MonoBehaviour
{
    [Header("Level para carregar")]
    [SerializeField] public string level;
    private AudioSource Som;
    public bool InterrompeMusica;
    private transicao _transicao;
   

    void Start()
    {
        Som = GetComponent<AudioSource>();
        _transicao = GameObject.FindWithTag("Transicao").GetComponent<transicao>();
    }

    public void Carregalevel()
    {
        StartCoroutine("Carrega");
    }
    IEnumerator Carrega()
    {

        Vibracao.vibra();

        if(_transicao != null)
        _transicao.inicia();

        if (Som != null)
        {
            Som.Play();
            yield return new WaitForSeconds(Som.clip.length);
        }
        else yield return new WaitForSecondsRealtime (1f);

        if (InterrompeMusica)
        { GameObject som= GameObject.FindWithTag("Musica");
            if (som !=null)
            {
                som.GetComponent<AudioSource>().Stop();
            }
        
        }
        else
        {
            GameObject som = GameObject.FindWithTag("Musica");
            if (som != null)
            {
               if(som.GetComponent<AudioSource>().isPlaying == false)
                    som.GetComponent<AudioSource>().Play();
            }
        }
        SceneManager.LoadScene(level);




    }

    // Update is called once per frame
    void Update()
    {
        if (level == "")
        {
            if(GetComponent<Button>() != null)
            {
                GetComponent<Button>().enabled = false;
                GetComponent<Image>().enabled = false;
                if (GetComponentInChildren<Text>() != null)
                    GetComponentInChildren<Text>().enabled = false;
            }
        }

        if (level != "")
        {
            if (GetComponent<Button>() != null)
            {
                GetComponent<Button>().enabled = true;
                GetComponent<Image>().enabled = true;
                if(GetComponentInChildren<Text>() != null)
                GetComponentInChildren<Text>().enabled = true;
            }
        }
    }
}
