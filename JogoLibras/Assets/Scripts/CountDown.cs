using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour
{
    public TMPro.TextMeshProUGUI Countdown;
    public GameObject Blur;
    private bool b;
    [SerializeField] public GameObject Iniciar;
    void Start()
    {
        Blur.GetComponent<transicao>().inicia();
        if(this.isActiveAndEnabled)
            Time.timeScale = 0;
        StartCoroutine(countdown(4));
    }
    public void Destroycount(){
        Destroy(this.gameObject);
    }

    public void denovo(){
        StartCoroutine(countdown(4));
    }

    IEnumerator countdown(int seconds)
    {
        int count = seconds;

        while (count > 0)
        {
            if(count==3)
            Countdown.text = "3";

            if (count == 2)
                Countdown.text = "2";

            if (count == 1)
                Countdown.text = "1";
            yield return new WaitForSecondsRealtime(1);
            count--;
        }

        // count down is finished...
        StartGame();
    }

    void StartGame()
    {
        Countdown.text = "";
        if (Iniciar != null)
            Iniciar.SetActive(true);
        Time.timeScale = 1;
        if(b==false){
            Blur.GetComponent<transicao>().finaliza();
            b=true;
        }
        this.gameObject.SetActive(false);
    }
}
