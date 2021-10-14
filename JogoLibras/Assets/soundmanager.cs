using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class soundmanager : MonoBehaviour
{
       [SerializeField]
        GameObject ImagemLigado;
        [SerializeField]
        GameObject ImagemDesligado;
        private bool muted = false;
        void Start()
        {
            muted = PlayerPrefs.GetInt("muted") == 1;
            if (muted == false)
            {
            this.GetComponent<Image>().sprite = ImagemLigado.GetComponent<Image>().sprite;

            }
            else
            {
            this.GetComponent<Image>().sprite = ImagemDesligado.GetComponent<Image>().sprite;
        }
            if (PlayerPrefs.HasKey("muted"))
            {
                Load();
            }
            else
            {
                PlayerPrefs.SetInt("muted", 1);
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
                AudioListener.pause = true;
            }
            else
            {
                muted = false;
                AudioListener.pause = false;
            }
            UpdateButtonIcon();
            Save();
        }

        private void Load()
        {
            muted = PlayerPrefs.GetInt("muted") == 1;
        }

        private void Save()
        {
            PlayerPrefs.SetInt("muted", muted ? 1 : 0);
        }



}
