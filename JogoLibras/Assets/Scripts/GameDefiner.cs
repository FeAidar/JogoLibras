using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameDefiner : MonoBehaviour
{
    public int Dificuldade;
    public int pack;
    public int Quantia;
    public int Etapa;
    public bool dialogo;

    [Header("Tempo Total de Jogo")]
    public int Tempo;

    [Header("Tempo de Estrelas")]
    public int TempoTresEstrelas;
    public int TempoDuasEstrelas;
    public int TempoUmaEstrela;

    [Header("Se � um jogo que perde ou ganha estrelas")]
    public bool PerdeEstrelas;


    [HideInInspector]    public int QuantiaEstrela;
    [HideInInspector] public string ID = "1";

    private static Dictionary<string, GameObject> _instancias = new Dictionary<string, GameObject>();
   

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
          
    string premio = (SceneManager.GetActiveScene().name + ".Dificuldade" + Dificuldade+ ".Pack" + pack + ".Quantia" +  Quantia + ".Etapa" + Etapa);
        if (QuantiaEstrela == 1)
        {
            
            if (PlayerPrefs.GetInt(premio) == 0)
                PlayerPrefs.SetInt(premio, 1);
            else return;

        }


        if (QuantiaEstrela == 2)
        {
            
            if (PlayerPrefs.GetInt(premio) > QuantiaEstrela)
                return;
            else
                PlayerPrefs.SetInt(premio, 2);

        }


        if (QuantiaEstrela == 3)
        {

            
            if (PlayerPrefs.GetInt(premio) > QuantiaEstrela)
                return;
            else
                PlayerPrefs.SetInt(premio, 3);

        }

        Debug.Log(premio + ": " + PlayerPrefs.GetInt(premio));
    }

    public void Apagatudo()
    {
        PlayerPrefs.DeleteAll();
    }
}
  

