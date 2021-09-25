using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDefiner : MonoBehaviour
{
    public int Dificuldade;
    public int pack;
    public int Quantia;
    public int QuantiaEstrela;
    
   
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
}
  

