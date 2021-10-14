using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ApagaDados : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Level para carregar")]
    [SerializeField] public string level;
    private AudioSource Som;
    public bool InterrompeMusica;
    private transicao _transicao;


    void Start()
    {
        Som = GetComponent<AudioSource>();
        _transicao = FindObjectOfType<transicao>();
    }

    public void Carregalevel()
    {
        StartCoroutine("Carrega");
    }
    IEnumerator Carrega()
    {

        PlayerPrefs.DeleteAll();

        if (Som != null)
            Som.Play();

        Vibracao.vibra();

        if (_transicao != null)
            _transicao.inicia();

        yield return new WaitForSecondsRealtime(1f);

        if (InterrompeMusica)
        {
            GameObject som = GameObject.FindWithTag("Musica");
            if (som != null)
            {
                som.GetComponent<AudioSource>().Stop();
            }

        }
        else
        {
            GameObject som = GameObject.FindWithTag("Musica");
            if (som != null)
            {
                if (som.GetComponent<AudioSource>().isPlaying == false)
                    som.GetComponent<AudioSource>().Play();
            }
        }
        SceneManager.LoadScene(level);




    }
}
