using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameDefiner : MonoBehaviour
{
    public int Dificuldade;
    public int pack;
    public int Quantia;
    [HideInInspector]    public int QuantiaEstrela;
    
   
    private static Dictionary<string, GameObject> _instancias = new Dictionary<string, GameObject>();
    public string ID = "1";

    void Awake()
    {
        if (_instancias.ContainsKey(ID))
        {
            var existing = _instancias[ID];


            if (existing != null)
            {
                if (ReferenceEquals(gameObject, existing))
                    return;

                Destroy(gameObject);

                return;
            }
        }


        _instancias[ID] = gameObject;

        DontDestroyOnLoad(gameObject);
    }

    public void ganhou()
    {
        if (QuantiaEstrela == 1)
        {
            string premio = (SceneManager.GetActiveScene().name + Dificuldade);
            PlayerPrefs.SetInt(premio, 1);

        }


        if (QuantiaEstrela == 2)
        {
            string premio = (SceneManager.GetActiveScene().name + Dificuldade);
            PlayerPrefs.SetInt(premio, 2);

        }


        if (QuantiaEstrela == 3)
        {

            string premio = (SceneManager.GetActiveScene().name + Dificuldade);
            PlayerPrefs.SetInt(premio, 3);

        }
    }
}
  

