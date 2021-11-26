using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCustomization : MonoBehaviour
{

    [Header("Parte do corpo")]
    public List<SpriteRenderer> ParteDoCorpo;


    [Header("Codigos de cor")]
    public List<string> Cores = new List<string>();

    private int coratual = 0;
    private Color cor;

    public void ProximaCor()
    {
        coratual++;
        if(coratual >= Cores.Count)
        {
            coratual = 0;
        }

       
        ColorUtility.TryParseHtmlString(Cores[coratual], out cor);

        //Debug.Log(cor);

        for (int i = 0; i < ParteDoCorpo.Count; i++)
        {
            ParteDoCorpo[i].color = cor;
            ConfirmaCor();
        }
    }

    public void AnteriorCor()
    {
        coratual--;
        if (coratual < 0)
        {
            coratual = Cores.Count - 1;
            ConfirmaCor();
        }

        
        ColorUtility.TryParseHtmlString(Cores[coratual], out cor);

        for (int i = 0; i < ParteDoCorpo.Count; i++)
        {
            ParteDoCorpo[i].color = cor;
        }
        //Debug.Log(cor);
    }


    public void ConfirmaCor()
    {
        PlayerPrefs.SetString(gameObject.name, Cores[coratual]);
        //Debug.Log(PlayerPrefs.GetString(gameObject.name, Cores[coratual]));
    }


}
