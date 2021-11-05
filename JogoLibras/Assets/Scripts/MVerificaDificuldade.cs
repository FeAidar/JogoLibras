using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MVerificaDificuldade : MonoBehaviour
{
    private GameDefiner controller;

    [Header("Coloque as imagens na ordem de dificuldade")]
    [SerializeField] List<GameObject> Dificuldade = new List<GameObject>();

    void Start()
    {
        controller = FindObjectOfType<GameDefiner>();
        Operator();
    }

    // Update is called once per frame
    public void Operator()
    {
        if (controller != null)
        {
            if(controller.Dificuldade == 1)
            {
                Dificuldade[0].SetActive(true);
                Debug.Log("Facil");

            }

            if (controller.Dificuldade == 2)
            {
                int d = Random.Range(0,2);
                Dificuldade[d].SetActive(true);
                Debug.Log("Medio");
            }

            if (controller.Dificuldade == 3)
            {
                Dificuldade[1].SetActive(true);
                Debug.Log("Dificil");
            }

        }
    }
}
