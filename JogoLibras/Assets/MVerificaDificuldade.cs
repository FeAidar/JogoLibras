using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MVerificaDificuldade : MonoBehaviour
{
    private GameDefiner controller;
    private Image image;

    [Header("Coloque as imagens na ordem de dificuldade")]
    [SerializeField] List<Sprite> Dificuldade = new List<Sprite>();

    void Start()
    {
        controller = FindObjectOfType<GameDefiner>();
        image = GetComponent<Image>();
        Operator();
        }

    // Update is called once per frame
    public void Operator()
    {
        if (controller != null)
        {
            if(controller.Dificuldade == 1)
            {
                image.sprite = Dificuldade[0];
                Debug.Log("Facil");

            }

            if (controller.Dificuldade == 2)
            {
                image.sprite = Dificuldade[Random.Range(0,2)];
                Debug.Log("Medio");
            }

            if (controller.Dificuldade == 3)
            {
                image.sprite = Dificuldade[1];
                Debug.Log("Dificil");
            }

        }
    }
}
