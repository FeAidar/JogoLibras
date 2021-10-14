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
    private bool muted = false;
    void Start()
    {
        muted = PlayerPrefs.GetInt("Vibra") == 1;
        if (muted == false)
        {
            this.GetComponent<Image>().sprite = ImagemLigado.GetComponent<Image>().sprite;
            

        }
        else
        {
            this.GetComponent<Image>().sprite = ImagemDesligado.GetComponent<Image>().sprite;
        }
        if (PlayerPrefs.HasKey("Vibra"))
        {
            Load();
        }
        else
        {
            PlayerPrefs.SetInt("Vibra", 1);
            Save();
        }

        AudioListener.pause = muted;
    }

    private void UpdateButtonIcon()
    {
        if (muted == false)
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
        if (muted == false)
        {
            muted = true;
            Vibracao.vibra();
        }
        else
        {
            muted = false;
            Vibracao.vibra();
        }
        UpdateButtonIcon();
        Save();
    }

    private void Load()
    {
        muted = PlayerPrefs.GetInt("Vibra") == 1;
    }

    private void Save()
    {
        PlayerPrefs.SetInt("Vibra", muted ? 1 : 0);
    }
}
