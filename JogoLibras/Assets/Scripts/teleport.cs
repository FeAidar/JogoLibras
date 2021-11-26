using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class teleport : MonoBehaviour
{
    [Header("Level para carregar")]
    [SerializeField] public string level;
    protected AudioSource Som;
    public bool InterrompeMusica;
    protected transicao _transicao;
    public bool sair;
    public bool CorteSeco;
    public bool Reset;
   

    void Start()
    {
        Som = GetComponent<AudioSource>();
        _transicao = GameObject.FindWithTag("Transicao").GetComponent<transicao>();
        
    }

    public void Carregalevel()
    {
        StartCoroutine("Carrega", level);
    }

    protected IEnumerator Carrega(string nivel)
    {
        //Debug.Log(Som);
        Vibracao.vibra();

        if(_transicao != null){
            if(!CorteSeco){
                _transicao.inicia();
            }    
        }

        if(Som != null){
            Som.Play();
            yield return new WaitForSecondsRealtime(Som.clip.length);
        }else{
            yield return new WaitForSecondsRealtime (0.5f);
        }
        yield return new WaitForSecondsRealtime(1f);
        if(InterrompeMusica){ 
            GameObject som= GameObject.FindWithTag("Musica");
            if(som !=null){
                som.GetComponent<AudioSource>().Stop();
            }
        
        }else{
            GameObject som = GameObject.FindWithTag("Musica");
            if(som != null){
                if(som.GetComponent<AudioSource>().isPlaying == false){
                    som.GetComponent<AudioSource>().Play();
                }    
            }
        }
        if(!sair){ 
            Time.timeScale = 1f;

            if(!Reset)
            SceneManager.LoadScene(nivel);
            else
            {
                Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
            }
        }else{
            //Debug.Log(_transicao);
            Application.Quit();
        }



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
