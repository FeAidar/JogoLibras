using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class BackButton : teleport
{
    private bool voltatela = true;
    private bool voltamenu;
    public bool disablebackbutton;
    public transicao Blur;
    public GameObject ConfigPrincipal;
    public GameObject ConfigMinigame;
    private bool foi;
    private int usos= 3;
    [SerializeField]GameObject dici;
    [SerializeField]TMP_Text texto;
    Scene opa;
    void Start()
    {
        Som = GetComponent<AudioSource>();
        _transicao = GameObject.FindWithTag("Transicao").GetComponent<transicao>();
        opa = SceneManager.GetActiveScene();
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
        if(opa.name == "JogoDaMenoria" || opa.name == "Mochila" || opa.name == "SinalComposto"|| opa.name == "Caca"){
            texto.text = usos + "/3";
        }else{
            texto.text = "";
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
    public void DiciBTM(){
        if(opa.name == "JogoDaMenoria" || opa.name == "Mochila" || opa.name == "SinalComposto"|| opa.name == "Caca"){
            if(usos >0){
                dici.SetActive(true);
                usos--;
            }
        }else{
            dici.SetActive(true);
        }
    }
    public void FechaDici(){
        dici.SetActive(false);
    }
}
