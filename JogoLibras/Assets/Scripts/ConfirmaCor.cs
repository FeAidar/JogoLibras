using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfirmaCor : MonoBehaviour
{
    [Header("Parte do corpo")]
    public List<SpriteRenderer> Cabelo;
    public List<SpriteRenderer> Pele;
    public List<SpriteRenderer> Camiseta;
    public List<SpriteRenderer> Calca;
    public List<SpriteRenderer> Sapato;
    // Start is called before the first frame update
    void Start()
    {

        confirmacor();

    }

    public void confirmacor()
    {
        for (int i = 0; i < Cabelo.Count; i++)
        {
            Color cor;
            ColorUtility.TryParseHtmlString(PlayerPrefs.GetString("CorCabelo"), out cor);
            Cabelo[i].color = cor;

        }

        for (int i = 0; i < Pele.Count; i++)
        {
            Color cor;
            ColorUtility.TryParseHtmlString(PlayerPrefs.GetString("CorPele"), out cor);
            Pele[i].color = cor;

        }

        for (int i = 0; i < Camiseta.Count; i++)
        {
            Color cor;
            ColorUtility.TryParseHtmlString(PlayerPrefs.GetString("CorCamiseta"), out cor);
            Camiseta[i].color = cor;

        }

        for (int i = 0; i < Calca.Count; i++)
        {
            Color cor;
            ColorUtility.TryParseHtmlString(PlayerPrefs.GetString("CorCalca"), out cor);
            Calca[i].color = cor;

        }

        if(Sapato.Count != 0)
        for (int i = 0; i < Sapato.Count; i++)
        {
            Color cor;
            ColorUtility.TryParseHtmlString(PlayerPrefs.GetString("CorSapato"), out cor);
            Sapato[i].color = cor;

        }

        Debug.Log("foi");
    }

}
