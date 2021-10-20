using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackButton : teleport
{
    private bool voltatela = true;
    private bool voltamenu;
    public bool disablebackbutton;
    public transicao Blur;
    public GameObject ConfigPrincipal;
    public GameObject ConfigMinigame;
    private bool foi;
    void Start()
    {
        Som = GetComponent<AudioSource>();
        _transicao = GameObject.FindWithTag("Transicao").GetComponent<transicao>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!disablebackbutton)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (voltatela)
                {
                    StartCoroutine("Carrega", level);

                }
                if (voltamenu)
                {

                        StartCoroutine("ResetButton");

                }

                return;
            }
        }
    }

    public void BackVoltaTela()
    {
        voltatela = true;
        voltamenu = false;
    }
   public void BackVoltaMenu() 
    {
        voltatela = false;
        voltamenu = true;
    }
    public void NaoFunciona()
    {
        if (!disablebackbutton)
            disablebackbutton = true;
        else
            disablebackbutton = false;
    }

    private IEnumerator ResetButton()
    {
        

           
            ConfigPrincipal.SetActive(false);
            ConfigMinigame.SetActive(false);
            Blur.finaliza();

            yield return new WaitForSeconds(1f * Time.deltaTime);
            BackVoltaTela();
            foi = false;
        
    }
}
