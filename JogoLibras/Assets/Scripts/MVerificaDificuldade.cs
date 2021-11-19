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
                Dificuldade[1].SetActive(false);
                Debug.Log("Facil");

            }else if (controller.Dificuldade == 2)
            {
                int d = Random.Range(0,2);
                Dificuldade[d].SetActive(true);
                if(d == 0){
                    Dificuldade[1].SetActive(false);
                }else{
                    Dificuldade[0].SetActive(false);
                }
                Debug.Log("Medio");
            }else if (controller.Dificuldade == 3)
            {
                Dificuldade[1].SetActive(true);
                Dificuldade[0].SetActive(false);
                Debug.Log("Dificil");
            }

        }
    }
}
