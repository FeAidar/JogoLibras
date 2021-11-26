using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float tempo;
    public float timeRemaining;
    public bool timerIsRunning = false;
    public Text timeText;
    public bool perdeu;
    private Slider slider;
    private GameObject posicaoestrela;
    private GameDefiner gameDefiner;
    public GameObject estrelaligada;
    public GameObject estreladesligada;
    private GameObject estrela3;
    private GameObject estrela2;
    private GameObject estrela1;

    private void Start()
    {
        gameDefiner = FindObjectOfType<GameDefiner>();

        if (tempo == 0 )
        { tempo = gameDefiner.Tempo; }

        timeRemaining = tempo;
        slider = FindObjectOfType<Slider>();
        if (slider != null)
        {
            posicaoestrela = GameObject.Find("posicaoestrela");
            slider.maxValue = tempo;
            estrela1 = GameObject.Find("T1.Estrela");
            estrela2 = GameObject.Find("T2.Estrela");
            estrela3 = GameObject.Find("T3.Estrela");
            StartCoroutine("GetStarsPositions");
        }

    }

    void Update()
    {
        if (slider != null)
        slider.maxValue = tempo;

        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                if (slider != null)
                    slider.value += Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                timeRemaining = 0;
                timerIsRunning = false;
                perdeu = true;
                if (slider != null)
                    slider.value = slider.maxValue;
            }

            if(slider!= null)
            {
                if (gameDefiner.PerdeEstrelas)
                {
                    if (posicaoestrela.GetComponent<RectTransform>().position.x <= estrela1.GetComponent<RectTransform>().position.x)
                        estrela1.GetComponent<Image>().sprite = estreladesligada.GetComponent<Image>().sprite;

                    if (posicaoestrela.GetComponent<RectTransform>().position.x <= estrela2.GetComponent<RectTransform>().position.x)
                        estrela2.GetComponent<Image>().sprite = estreladesligada.GetComponent<Image>().sprite;

                   if(posicaoestrela.GetComponent<RectTransform>().position.x <= estrela3.GetComponent<RectTransform>().position.x)
                        estrela3.GetComponent<Image>().sprite = estreladesligada.GetComponent<Image>().sprite;
                }
                else
                {
                    if (posicaoestrela.GetComponent<RectTransform>().position.x >= estrela1.GetComponent<RectTransform>().position.x)
                        estrela1.GetComponent<Image>().sprite = estrelaligada.GetComponent<Image>().sprite;

                    if (posicaoestrela.GetComponent<RectTransform>().position.x >= estrela2.GetComponent<RectTransform>().position.x)
                        estrela2.GetComponent<Image>().sprite = estrelaligada.GetComponent<Image>().sprite;

                    if (posicaoestrela.GetComponent<RectTransform>().position.x >= estrela3.GetComponent<RectTransform>().position.x)
                        estrela3.GetComponent<Image>().sprite = estrelaligada.GetComponent<Image>().sprite;
                 
                }
            }
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    IEnumerator GetStarsPositions()
    {
        //Debug.Log("Chamou");
       if (gameDefiner.PerdeEstrelas == true)
        {
            slider.value = gameDefiner.Tempo - gameDefiner.TempoTresEstrelas;
            yield return
            estrela1.GetComponent<RectTransform>().position = posicaoestrela.GetComponent<RectTransform>().position;
            yield return
            slider.value = gameDefiner.Tempo - gameDefiner.TempoDuasEstrelas;
            yield return
            estrela2.GetComponent<RectTransform>().position = posicaoestrela.GetComponent<RectTransform>().position;
            yield return
            slider.value = gameDefiner.Tempo - gameDefiner.TempoUmaEstrela;
            yield return
            estrela3.GetComponent<RectTransform>().position = posicaoestrela.GetComponent<RectTransform>().position;

            estrela1.GetComponent<Image>().sprite = estrelaligada.GetComponent<Image>().sprite;
            estrela2.GetComponent<Image>().sprite = estrelaligada.GetComponent<Image>().sprite;
            estrela3.GetComponent<Image>().sprite = estrelaligada.GetComponent<Image>().sprite;
        }
        if (gameDefiner.PerdeEstrelas == false)
        {
            slider.value = gameDefiner.Tempo - gameDefiner.TempoTresEstrelas;
            yield return
            estrela3.GetComponent<RectTransform>().position = posicaoestrela.GetComponent<RectTransform>().position;
            yield return
            slider.value = gameDefiner.Tempo - gameDefiner.TempoDuasEstrelas;
            yield return
            estrela2.GetComponent<RectTransform>().position = posicaoestrela.GetComponent<RectTransform>().position;
            yield return
            slider.value = gameDefiner.Tempo - gameDefiner.TempoUmaEstrela;
            yield return
            estrela1.GetComponent<RectTransform>().position = posicaoestrela.GetComponent<RectTransform>().position;
            estrela1.GetComponent<Image>().sprite = estreladesligada.GetComponent<Image>().sprite;
            estrela2.GetComponent<Image>().sprite = estreladesligada.GetComponent<Image>().sprite;
            estrela3.GetComponent<Image>().sprite = estreladesligada.GetComponent<Image>().sprite;

        }
        slider.value = 0;
    }
}
