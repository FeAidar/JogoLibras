using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RumbleManager : MonoBehaviour
{
    [SerializeField]
    GameObject ImagemLigado;
    [SerializeField]
    GameObject ImagemDesligado;
    private int muted;
    void Start()

    {

        if (PlayerPrefs.HasKey("Vibra"))
        {
            if (PlayerPrefs.GetInt("Vibra") == 1)

            {
                muted = 1;
                Debug.Log("Sem vibra");
                
            }

        }
        Load();
    }

    private void UpdateButtonIcon()
    {
        if (muted == 0)
        {
            this.GetComponent<Image>().sprite = ImagemLigado.GetComponent<Image>().sprite;
        }
        else
        {
            this.GetComponent<Image>().sprite = ImagemDesligado.GetComponent<Image>().sprite;
        }
    }

    public void OnButtonPress()
    {
        if (muted == 0)
        {
            muted = 1;
            
        }
        else
        {
            muted = 0;
            Handheld.Vibrate();
            
        }
        UpdateButtonIcon();
        Save();
    }

    private void Load()
    {
        muted = PlayerPrefs.GetInt("Vibra");
        if (muted == 0)
        {
            this.GetComponent<Image>().sprite = ImagemLigado.GetComponent<Image>().sprite;

        }
        else
        {
            this.GetComponent<Image>().sprite = ImagemDesligado.GetComponent<Image>().sprite;
        }



    }

    private void Save()
    {
        PlayerPrefs.SetInt("Vibra", muted);


    }
}
