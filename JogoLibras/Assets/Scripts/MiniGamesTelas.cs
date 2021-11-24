using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using UnityEngine.Audio;

public class MiniGamesTelas : MonoBehaviour
{
    [Header("Para todas as telas")]
    public transicao blur;
    private GameDefiner controller;


    [Header("Se voce quer que o tempo pare ao entrar na tela. (Nao esqueca de invocar o retorno")]
    public bool ParaTempo;

    [Header("Se tem algum objeto que precisa ser desligado ao entrar no menu (Nao esqueca de invocar o retorno")]
    public List<GameObject> ObjetosParaDesligar = new List<GameObject>();
    [SerializeField]private UnityEvent DesligaCodigos;
    [SerializeField]private AudioSource musica;

    [Header("Tela de Vitoria")]
    public bool TelaDeVitoria;
    public GameObject Estrela1;
    public GameObject Estrela2;
    public GameObject Estrela3;
    public TMPro.TextMeshProUGUI frase;
    public TMPro.TextMeshProUGUI countdown;
    
    public string ConseguiuUmaEstrela;
    public string ConseguiuDuasEstrelas;
    public string ConseguiuTresEstrelas;
  


    void OnEnable()
    {
        if (TelaDeVitoria)
        {
            Estrela1.SetActive(false);
            Estrela2.SetActive(false);
            Estrela3.SetActive(false);
            musica.mute = true;
            controller = FindObjectOfType<GameDefiner>();
             Starchecker();
            if (ParaTempo)
                paratempo();
            if(ObjetosParaDesligar.Count >0)
            {
                for (int i = 0; i < ObjetosParaDesligar.Count; i++)
                {
                    ObjetosParaDesligar[i].SetActive(false);
                }
            }
            DesligaCodigos.Invoke();
        }
        blur.inicia();
    }

    // Update is called once per frame
    void Starchecker()
    {
        
        string premio = (SceneManager.GetActiveScene().name + ".Dificuldade" + controller.Dificuldade + ".Pack" + controller.pack + ".Quantia" + controller.Quantia + ".Etapa" + controller.Etapa);
        Debug.Log(PlayerPrefs.GetInt(premio));

        if (PlayerPrefs.GetInt(premio) == 1)
            {
            Estrela1.SetActive(true);
            Estrela2.SetActive(false);
            Estrela3.SetActive(false);
            frase.text = ConseguiuUmaEstrela;
            countdown.text = "Você completou em " + (FindObjectOfType<Timer>().tempo - FindObjectOfType<Timer>().timeRemaining).ToString("0") + " segundos!";                
        }

        if (PlayerPrefs.GetInt(premio) == 2)
        {
            Estrela1.SetActive(true);
            Estrela2.SetActive(true);
            Estrela3.SetActive(false);
            frase.text = ConseguiuDuasEstrelas;
            countdown.text = "Você completou em " + (FindObjectOfType<Timer>().tempo - FindObjectOfType<Timer>().timeRemaining).ToString("0") + " segundos!";

        }

        if (PlayerPrefs.GetInt(premio) == 3)
        {
            Estrela1.SetActive(true);
            Estrela2.SetActive(true);
            Estrela3.SetActive(true);
            frase.text = ConseguiuTresEstrelas;
            countdown.text = "Você completou em " + (FindObjectOfType<Timer>().tempo - FindObjectOfType<Timer>().timeRemaining).ToString("0") + " segundos!";

        }

        if (PlayerPrefs.GetInt(premio) == 0)
        {
            Estrela1.SetActive(false);
            Estrela2.SetActive(false);
            Estrela3.SetActive(false);
        }
          
           // Debug.Log(PlayerPrefs.GetInt("nivelmochila1"));

   
    }

    public void paratempo()
    {
        if(Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }

        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
        }

    }

    public void LigaObjetosDeVolta()
    {
        
        for (int i = 0; i < ObjetosParaDesligar.Count; i++)
        {
            ObjetosParaDesligar[i].SetActive(false);
        }
    }

}
