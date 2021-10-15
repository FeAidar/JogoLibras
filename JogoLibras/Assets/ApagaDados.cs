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

        neverdestroy[] Kills = GameObject.FindObjectsOfType<neverdestroy>();
        foreach(neverdestroy Kill in Kills)
        {
            Kill.GetComponent<neverdestroy>().Destruir();
        }

        Destroy(GameObject.FindGameObjectWithTag("GameController"));

        if (Som != null)
            Som.Play();

        Vibracao.vibra();

        if (_transicao != null)
            _transicao.inicia();
        PlayerPrefs.DeleteAll();

        yield return new WaitForSecondsRealtime(1f);
       
        Time.timeScale = 1;

   SceneManager.LoadScene(level);




    }
}
